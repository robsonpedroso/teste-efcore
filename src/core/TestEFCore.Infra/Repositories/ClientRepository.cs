using TestEFCore.Domain.Contracts.Repositories;
using TestEFCore.Domain.Entities;

namespace TestEFCore.Infra.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IUnitOfWork uow): base(uow)
        {
        }
    }
}
