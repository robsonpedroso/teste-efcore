using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Contracts.Repositories;
using TestEFCore.Domain.Contracts.Services;
using TestEFCore.Domain.Entities;

namespace TestEFCore.Domain.Services
{
    public class ClientService : IClientService, IDisposable
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<bool> Delete(Guid id)
        {
            await _clientRepository.Delete(id);
            return await Task.FromResult(true);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientRepository.GetAll();
        }
        public async Task<Client> Get(Guid id)
        {
            return await _clientRepository.Find(id);
        }

        public async Task<bool> Insert(Client client)
        {
            return await _clientRepository.Insert(client);
        }

        public async Task<bool> Update(Client client)
        {
            return await _clientRepository.Update(client);
        }
    }
}
