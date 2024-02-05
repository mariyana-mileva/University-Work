using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class User
    {
        protected int id;
        protected string firstName;
        protected string lastName;
        protected string email;

        protected User(int id, string fName, string lName, string email)
        {
            this.id = id;
            this.firstName = fName;
            this.lastName = lName;
            this.email = email;
        }
        protected User(int id)
        {
            this.id = id;
      
        }
        protected User()
        {

        }



        public int ID { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email= value; } }
    }
}
