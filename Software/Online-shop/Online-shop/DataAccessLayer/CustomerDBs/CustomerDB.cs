using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Org.BouncyCastle.Crypto.Tls;
using System.Data;

namespace DataAccessLayer.CustomerDBs
{
    public class CustomerDB : ICustomerDB
    {

        MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");


        public int? getCustomerID(string email)
        {
            try
            {
                int id = 0;
                string cmdString = "SELECT CustomerID from customers where Email = '" + email + "'";
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
        public Customer registerCustomerInDB(string email, string fName, string lName, string password)
        {
            Customer customer;
            try
            {
                int id = 0;
                string cmdString = "INSERT INTO customers(FirstName, LastName, Email, Password)Values('" + fName + "','" + lName + "','" + email + "','" + password + "')";
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                conn.Open();

                command.ExecuteNonQuery();

                id = Convert.ToInt32(getCustomerID(email));

                customer = new Customer(id, fName, lName, email);

                return customer;
            }
            catch (Exception)
            {

                throw;

            }
            finally { conn.Close(); }

        }


        public Customer? logInCustomer(string email, string password)
        {
            string cmdString = "SELECT CustomerID, FirstName, LastName, Email, Password FROM customers WHERE Email = @email AND Password = @password";
            Customer customer = null;
            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                conn.Open();

                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                MySqlDataReader dr = command.ExecuteReader();


                if (dr.Read())
                {
                    customer = new Customer(Convert.ToInt32(dr.GetValue(0).ToString()), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString());

                }
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }


    }
}
