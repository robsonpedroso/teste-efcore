using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Entities;

namespace TestEFCore.Domain.Contracts.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> Get(Guid id);
        Task<bool> Insert(Client client);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Client client);

    }
}
