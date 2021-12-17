using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.VO;

namespace TestEFCore.Domain.Entities
{
    public class Client: BaseEntitie
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }

        public Client()
        {

        }
        public Client(DTO.Client client)
        {
            this.Id = client.Id;
            this.Name = client.Name;
            this.Email = client.Email;
            this.Password = client.Password;

            this.Address = new Address(client.Address);
        }

    }
}
