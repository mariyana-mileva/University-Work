using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee: User
    {
        public byte[] image;
        public Employee(int id, string fname, string lname, string email) : base(id, fname, lname, email) { }
        public Employee(int id): base(id) { }

        public Employee() { }
    }
}
