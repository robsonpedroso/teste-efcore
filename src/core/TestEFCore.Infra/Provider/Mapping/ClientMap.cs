using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestEFCore.Domain.Entities;
using TestEFCore.Domain.VO;

namespace TestEFCore.Infra.Provider.Mapping
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.Password).HasColumnName("password");
            builder.Property(e => e.CreateAt).HasColumnName("create_at");
            builder.Property(e => e.UpdateAt).HasColumnName("update_at");
            builder.Property(e => e.Removed).HasColumnName("removed");

            builder.Property(e => e.Address)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Address>(v, (JsonSerializerOptions)null));
        }
    }
}
