using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore.Domain.Contracts.Repositories
{
    public interface IUnitOfWorkTransaction : IDisposable
    {
        bool IsConnectionOpen { get; }

        Task RollbackAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
