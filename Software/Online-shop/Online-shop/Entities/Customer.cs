using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer: User
    {
        public Customer(int id, string fname, string lname, string email) : base(id, fname, lname, email)
        {
            


        }
    }
}
