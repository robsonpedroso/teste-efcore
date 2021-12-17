using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Entities;

namespace TestEFCore.Domain.Contracts.Repositories
{
    public interface IClientRepository: IRepositoryBase<Client>
    {
    }
}
