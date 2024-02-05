using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EmployeeDBs
{
    public class EmployeeAuthorizationDB : IEmployeeAuthorization
    {
        MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");

        public Employee logInEmployee(string id, string password)
        {
            string cmdString = "SELECT EmployeeID, FirstName, LastName, Email, Password FROM employees WHERE EmployeeID = @id AND Password = @password";
            Employee employee = null;
            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                conn.Open();

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@password", password);

                MySqlDataReader dr = command.ExecuteReader();


                if (dr.Read())
                {

                    employee = new Employee(Convert.ToInt32(dr.GetValue(0).ToString()), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString());
                    return employee;
                }

                return employee;

            }
            catch (MySqlException ex)
            {

                throw new InvalidOperationException("Help");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
