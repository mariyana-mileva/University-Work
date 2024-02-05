using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EmployeeDBs
{
    public interface IEmployeeDB
    {
        Employee updateEmployee(string email, string fname, string lname, Employee emp);

        void UploadImage(MemoryStream ms, Employee emp);
        MemoryStream? RetrieveImage(MemoryStream ms, Employee emp);
    }
}
