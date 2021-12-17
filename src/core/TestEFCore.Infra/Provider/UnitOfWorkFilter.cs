using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Contracts.Repositories;

namespace TestEFCore.Infra.Provider
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWorkTransaction transaction;

        public UnitOfWorkFilter(IUnitOfWorkTransaction transaction)
        {
            this.transaction = transaction;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!transaction.IsConnectionOpen)
                throw new NotSupportedException("The provided connection was not open!");

            var executedContext = await next();

            try
            {

                if (executedContext.Exception == null)
                {
                    await transaction.CommitAsync();
                }
                else
                {
                    await transaction.RollbackAsync();
                }
            }
            catch (Exception ex)
            {
                var t = ex;
                throw;
            }

            GC.SuppressFinalize(this);
        }
    }
}
