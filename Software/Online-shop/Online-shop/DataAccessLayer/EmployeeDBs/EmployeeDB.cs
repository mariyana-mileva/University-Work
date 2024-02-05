using Entities;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Security.AccessControl;

namespace DataAccessLayer.EmployeeDBs
{
    public class EmployeeDB : IEmployeeDB
    {
        MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");
       
        public Employee updateEmployee(string email, string fname, string lname, Employee emp)
        {
            try
            {
                string cmdString = "UPDATE employees SET Email = '" + email + "',FirstName = '" + fname + "', LastName = '" + lname + "' WHERE EmployeeID = '" + emp.ID + "'";
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                conn.Open();
                command.ExecuteNonQuery();

                emp.Email = email;
                emp.FirstName = fname;
                emp.LastName = lname;

                return emp;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }


        }

        public void UploadImage(MemoryStream ms, Employee emp)
        {
            try
            {
                byte[] img = ms.ToArray();

                string cmdString = "UPDATE employees SET ProfilePicture = @img WHERE EmployeeID = @id";
                MySqlCommand command = new MySqlCommand(cmdString, conn);



                conn.Open();


                command.Parameters.AddWithValue("@img", img);
                command.Parameters.AddWithValue("@id", emp.ID);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { conn.Close(); }

        }

        public MemoryStream? RetrieveImage(MemoryStream ms, Employee emp)
        {
            try
            {
                string cmdString = "SELECT ProfilePicture FROM employees WHERE EmployeeID = @id";
                byte[]? img = null;

                MySqlCommand command = new MySqlCommand(cmdString, conn);

                conn.Open();

                command.Parameters.AddWithValue("@id", emp.ID);

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (DBNull.Value.Equals(dr.GetValue(0)))
                    {
                        return null;
                    }
                    else
                    {
                        img = (byte[]?)dr.GetValue(0);

                    }

                }


                ms = new MemoryStream(img);

                return ms;

            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }

        }
    }
}
