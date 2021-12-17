using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T>: IDisposable
    {
        Task<IEnumerable<T>> GetAll();
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);

        Task<T> Find(Guid id);
        Task<bool> Save();
    }
}
