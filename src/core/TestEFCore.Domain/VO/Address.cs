using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore.Domain.VO
{
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Contry { get; set; }
        public string Complement { get; set; }


        public Address()
        {

        }

        public Address(DTO.Address address)
        {
            this.Street = address.Street;
            this.Number = address.Number;
            this.ZipCode = address.ZipCode;
            this.State = address.State;
            this.Contry = address.Contry;
            this.Complement = address.Complement;
        }

    }
}
