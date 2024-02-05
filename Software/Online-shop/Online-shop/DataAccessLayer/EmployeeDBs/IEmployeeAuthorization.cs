using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EmployeeDBs
{
    public interface IEmployeeAuthorization
    {
        Employee logInEmployee(string id, string password);
    }
}
