using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Group_project_searching
{
    class DBHelper
    {
        public SqlConnection sc = new SqlConnection(@"Data Source=LAPTOP-QD7GHJLS\SQLEXPRESS;Initial Catalog=WPC;Integrated Security=True");


        public void FetchData(List<Employees> listOfEmployees, Employees employee)
        {
            //counter = _counter;
            //post = _post;
            try
            {
                sc.Open();
                SqlCommand command = new SqlCommand("select EmployeeNumber, FirstName, LastName From EMPLOYEE", sc);
                SqlDataReader srd = command.ExecuteReader();
                listOfEmployees.Clear();
                while (srd.Read())
                {
                    employee = new Employees();
                    employee.getEmployeeID = Convert.ToInt32(srd.GetValue(0).ToString());
                    employee.getFName = srd.GetValue(1).ToString();
                    employee.getLName = srd.GetValue(2).ToString();

                    listOfEmployees.Add(employee);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
        public void SearchEmployee(string fName, string lName, List<Employees> listOfEmployees, Employees employee)
        {
           
            try
            {
                
                sc.Open();
                SqlCommand command = new SqlCommand("select EmployeeNumber, FirstName, LastName From EMPLOYEE WHERE FirstName = '" + fName + "'OR LastName = '" + lName + "'", sc);
                SqlDataReader srd = command.ExecuteReader();
                listOfEmployees.Clear();
                while (srd.Read())
                {
                    employee = new Employees();

                    employee.getEmployeeID = Convert.ToInt32(srd.GetValue(0).ToString());
                    employee.getFName = srd.GetValue(1).ToString();
                    employee.getLName = srd.GetValue(2).ToString();


                    listOfEmployees.Add(employee);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                string error = $"There is an error with the database";
            }
        }

        public void SearchEmployeeByID(int Id, List<Employees> listOfEmployees, Employees employee)
        {

            try
            {

                sc.Open();
                SqlCommand command = new SqlCommand("select EmployeeNumber, FirstName, LastName From EMPLOYEE WHERE EmployeeNumber = '" + Id +"'", sc);
                SqlDataReader srd = command.ExecuteReader();
                listOfEmployees.Clear();
                while (srd.Read())
                {
                    employee = new Employees();

                    employee.getEmployeeID = Convert.ToInt32(srd.GetValue(0).ToString());
                    employee.getFName = srd.GetValue(1).ToString();
                    employee.getLName = srd.GetValue(2).ToString();


                    listOfEmployees.Add(employee);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                string error = $"There is an error with the database";
            }
        }
    }
}
