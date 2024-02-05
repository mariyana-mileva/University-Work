using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DataAccessLayer.CustomerDBs
{
    public interface ICustomerDB
    {
        Customer registerCustomerInDB(string email, string fname, string lname, string password);
        bool? checkForRepeatingEmail(string email);

        Customer? logInCustomer(string email, string password);
        int? getCustomerID(string email);


    }
}
