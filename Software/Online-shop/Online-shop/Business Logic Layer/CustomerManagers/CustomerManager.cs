using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1;
using Entities;
using DataAccessLayer.CustomerDBs;

namespace BusinessLogicLayer.CustomerManagers
{

    public class CustomerManager
    {
        CustomerDB customer = new CustomerDB();

        public Customer RegisterCustomer(string email, string fname, string lname, string passwrod)
        {
            return customer.registerCustomerInDB(email, fname, lname, passwrod);
        }

        public bool? checkForRepeatingEmail(string email)
        {
            return customer.checkForRepeatingEmail(email);
        }

        public Customer? logInCustomer(string email, string password)
        {
            return customer.logInCustomer(email, password);
        }


    }
}
