using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Open();
        IUnitOfWorkTransaction BeginTransaction();
        object GetContext();
    }
}
