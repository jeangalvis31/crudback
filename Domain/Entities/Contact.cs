using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
    }
}