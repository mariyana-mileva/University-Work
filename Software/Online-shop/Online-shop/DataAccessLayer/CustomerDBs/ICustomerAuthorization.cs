using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DataAccessLayer.CustomerDBs
{
    public interface ICustomerAuthorization
    {
        Customer RegisterCustomer(string email, string fName, string lName, string password);
        //void LogInCustomer(Customer customer);
        bool? checkForRepeatingEmail(string email);
    }
}
