using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomerDBs
{
    public class CustomerAuthorizationDB : ICustomerAuthorization
    {
        MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");

        public int? getCustomerID(string email)
        {
            try
            {
                int id = 0;
                string cmdString = "SELECT CustomerID from customers where Email = @email";
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    id = Convert.ToInt32(dr.GetValue(0).ToString());
                }
                return id;

            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
            finally
            {
                conn.Close();
            }


        }
        public Customer RegisterCustomer(string email, string fName, string lName, string password)
        {
            Customer customer;
            try
            {
                string cmdString = "INSERT INTO customers(FirstName, LastName, Email, Password)Values(@fName, @lName, @email, @password)";
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                conn.Open();
                command.ExecuteNonQuery();
                customer = new Customer(Convert.ToInt32(getCustomerID(email)), fName, lName, email);

                return customer;

            }
            catch
            {

                throw new InvalidOperationException("Data could not be read");
            }

        }

        public bool? checkForRepeatingEmail(string email)
        {
            try
            {
                string cmdString = "SELECT Email from customers where Email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    if (email == dr.GetValue(0).ToString())
                    {
                        return true;
                    }
                }
                return false;

            }
            catch
            {
                return null;
                throw;
            }
            finally
            {
                conn.Close();

            }



        }
    }
}
