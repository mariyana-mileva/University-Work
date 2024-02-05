using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_project_searching
{
    class Employees
    {
        int employeeID;
        string fName;
        string lName;

        public Employees()
        {
         
        }
        public Employees(int employeeID, string firstName, string lastName)
        {
            this.employeeID = employeeID;
            this.fName = firstName;
            this.lName = lastName;
        }

        public int getEmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string getFName
        {
            get { return fName; }
            set { fName = value; }
        }
        public string getLName
        {
            get { return lName; }
            set { lName = value; }
        }
    }
}
