using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EmployeeDBs;
using Entities;


namespace BusinessLogicLayer.EmployeeManagers
{
    public class EmployeeAuthorizationManager
    {
        IEmployeeAuthorization employeeAuthorization = new EmployeeAuthorizationDB();

        public Employee logInEmployee(string id, string password)
        {
            return employeeAuthorization.logInEmployee(id, password);
        }
    }
}
