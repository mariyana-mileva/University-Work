using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer.CustomerDBs;
using Entities;
using MySql.Data.MySqlClient;

namespace BusinessLogicLayer.CustomerManagers
{
    public class CustomerAuthorizationManager
    {
        private ICustomerAuthorization customerAuthorization = new CustomerAuthorizationDB();


        public Customer RegisterCustomer(string email, string fName, string lName, string password)
        {
            return customerAuthorization.RegisterCustomer(email, fName, lName, password);
        }

        public bool? checkForRepeatingEmail(string email)
        {
            return customerAuthorization.checkForRepeatingEmail(email);
        }




    }
}
