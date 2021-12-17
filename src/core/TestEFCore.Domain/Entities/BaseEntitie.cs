using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore.Domain.Entities
{
    public class BaseEntitie
    {
        public Guid Id { get; set; }
        public bool Removed { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
