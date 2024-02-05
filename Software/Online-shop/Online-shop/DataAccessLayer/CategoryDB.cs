using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class CategoryDB: ICategoriesDB
    {
        private MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");


        public bool? checkForRepeatingCategory(string name)
        {
            try
            {
                string cmdString = "SELECT Category_Name from categories where Category_Name = @name";
        

                MySqlCommand command = new MySqlCommand(cmdString, conn);

                command.Parameters.AddWithValue("@name", name);

                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();

                

                while (dr.Read())
                {
                    
                    if (name.ToLower() == dr.GetValue(0).ToString().ToLower())
                    {
                        return true;
                    }
                }
                return false;

            }
            catch(MySqlException ex)
            {
                return null;
                throw ex;
                
            }
            finally
            {
                conn.Close();

            }
        }
            public int? getCategoryID(string name)
            {
            try
            {
                int id = 0;
                string cmdString = "SELECT ID from categories where Category_Name = @name";
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                command.Parameters.AddWithValue("@name", name);

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
            catch (MySqlException)
            {
                return null;
                throw;
            }
            finally
            {
                conn.Close();
            }


        }

        public Category CreateNewCategoryAndAddToDB(string name, Employee emp)
        {
            Category category = new Category();

            string cmdString = "INSERT INTO `categories`(`Category_Name`, `Added_By_Employee_ID`) VALUES (@name, @employeeID)";

            int id = 0;

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@employeeID", emp.ID);

                conn.Open();

                

                command.ExecuteNonQuery();

                category.Name = name;
                category.AddedByEmployee = emp;
                category.ID = Convert.ToInt32(getCategoryID(name));


                return category;

            }catch(MySqlException) 
            {
                return null;
                throw;
                
            }
            finally { conn.Close(); }
            
        }


        public List<Category>? GetAllCategories() 
        {
            List<Category> categories = new List<Category>();
            Category category;
            Employee emp;

            string cmdString = "SELECT ID, Category_Name, Added_By_Employee_ID from categories WHERE Parent_ID = 0";

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
          
                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    emp = new Employee(Convert.ToInt32(dr.GetValue(2).ToString()));

                    category = new Category();
                    category.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    category.Name = dr.GetValue(1).ToString();
                    category.AddedByEmployee = emp;

                    categories.Add(category);
                }

                return categories;
            }
            catch(MySqlException) 
            {
                return null;
                throw;
               
            }
            finally { conn.Close(); }


        }

        public List<Category>? GetAllSubCategories(Category category)
        {
            List<Category> categories = new List<Category>();
            Employee emp;

            string cmdString = "SELECT ID, Parent_ID, Category_Name, Added_By_Employee_ID from categories WHERE Parent_ID = @parentID";

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                command.Parameters.AddWithValue("@parentID", category.ID);

                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    emp = new Employee(Convert.ToInt32(dr.GetValue(3).ToString()));

                    Category subCategory = new Category();
                    subCategory.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    subCategory.Name = dr.GetValue(2).ToString();
                    subCategory.ParentID = Convert.ToInt32(dr.GetValue(1));
                    subCategory.AddedByEmployee = emp;

                    categories.Add(subCategory);
                }

                return categories;
            }
            catch (MySqlException)
            {
                return null;
                throw;

            }
            finally { conn.Close(); }


        }

        public string? getCategoryName(int id)
        {
            string cmdString = "SELECT CategoryName from category WHERE CategoryID = @id";
            string name = null;
            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    
                    name = dr.GetValue(0).ToString();
                 
                }

                return name;
            }
            catch (Exception)
            {
                return null;

            }
            finally { conn.Close(); }

        }
    }
}
