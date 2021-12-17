using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO.Compression;
using TestEFCore.Application;
using TestEFCore.Domain.Contracts.Applications;
using TestEFCore.Domain.Contracts.Repositories;
using TestEFCore.Domain.Contracts.Services;
using TestEFCore.Domain.Services;
using TestEFCore.Infra.Provider;
using TestEFCore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GzipCompressionProviderOptions>(
    options => options.Level = CompressionLevel.Optimal);

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});


builder.Services.AddTransient<IClientApplication, ClientApplication>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddTransient<StoreDBContext>();

builder.Services.AddTransient<IUnitOfWorkTransaction>((serviceProvider) =>
{
    var uow = serviceProvider.GetService<IUnitOfWork>();

    uow.Open();

    return uow.BeginTransaction();
});


builder.Services.AddScoped<UnitOfWorkFilter>();
builder.Services.Configure<MvcOptions>(o => o.Filters.AddService<UnitOfWorkFilter>(2));


var contractResolver = new DefaultContractResolver
{
    NamingStrategy = new SnakeCaseNamingStrategy()
};

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = contractResolver;
    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
    options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
    options.SerializerSettings.Formatting = Formatting.None;
    options.SerializerSettings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
    options.SerializerSettings.FloatParseHandling = FloatParseHandling.Double;
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
    options.SerializerSettings.Culture = new System.Globalization.CultureInfo("en-US");
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
