using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EmployeeDBs;

namespace BusinessLogicLayer.EmployeeManagers
{
    public class EmployeeManager
    {
        EmployeeDB empDB = new EmployeeDB();

        public Employee updateEmployee(string email, string fname, string lname, Employee emp)
        {
            return empDB.updateEmployee(email, fname, lname, emp);
        }

        public void UploadImage(MemoryStream ms, Employee emp)
        {
            empDB.UploadImage(ms, emp);

        }
        public MemoryStream? RetrieveImage(MemoryStream ms, Employee emp)
        {
            return empDB.RetrieveImage(ms, emp);
        }

    }
}
