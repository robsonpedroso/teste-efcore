using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Contracts.Applications;
using TestEFCore.Domain.Contracts.Repositories;
using TestEFCore.Domain.Contracts.Services;
using TestEFCore.Domain.DTO;
using Entities = TestEFCore.Domain.Entities;

namespace TestEFCore.Application
{
    public class ClientApplication : IClientApplication
    {
        protected readonly IClientService _clientService;
        public ClientApplication(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _clientService.Delete(id);
        }

        public async Task<Client> Find(Guid id)
        {
            return new Client(await _clientService.Get(id));
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return (await _clientService.Get()).ToList().Select(x => new Client(x));
        }

        public async Task<bool> Insert(Client client)
        {
            return await _clientService.Insert(new Entities.Client(client));
        }

        public async Task<bool> Update(Client client)
        {
            return await _clientService.Update(new Entities.Client(client));
        }
    }
}
