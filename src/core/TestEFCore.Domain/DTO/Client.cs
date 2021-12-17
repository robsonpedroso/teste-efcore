using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore.Domain.DTO
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Address Address { get; set; }

        public Client()
        {

        }
        public Client(Entities.Client client)
        {
            this.Id = client.Id;
            this.Name= client.Name;
            this.Email = client.Email;
            this.Password = client.Password;

            this.Address = new Address(client.Address);
        }
    }
}
