using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.DTO;

namespace TestEFCore.Domain.Contracts.Applications
{
    public interface IClientApplication
    {
        Task<IEnumerable<Client>> Get();
        Task<bool> Insert(Client client);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Client client);
        Task<Client> Find(Guid id);

    }
}
