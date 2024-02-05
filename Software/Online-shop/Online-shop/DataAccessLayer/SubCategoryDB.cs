using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class SubCategoryDB: ISubCategoryDB
    {
        MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");

        public bool? checkForRepeatingSubCategory(string name)
        {
            try
            {
                string cmdString = "SELECT Name from sub_category where Name = @name";


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

        public int? getSubCategoryID(string name)
        {
            try
            {
                int id = 0;
                string cmdString = "SELECT Sub_CategoryID from sub_category where Name = @name";
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

        public SubCategory CreateNewSubCategoryAndAddToDB(string name, Employee emp, Category category)
        {
            SubCategory subCategory = new SubCategory();

            string cmdString = "INSERT INTO sub_category(Name, CategoryID, AddedByEmployee) Values(@name, @categoryID, @employeeID)";

            int id = 0;

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@categoryID", category.ID);
                command.Parameters.AddWithValue("@employeeID", emp.ID);
                

                conn.Open();



                command.ExecuteNonQuery();

                id = Convert.ToInt32(getSubCategoryID(name));

                subCategory.Name = name;
                subCategory.AddedByEmployee = emp;
                subCategory.ID = id;
                subCategory.Category = category;


                return subCategory;

            }
            catch (Exception)
            {
                return null;
                throw;

            }
            finally { conn.Close(); }

        }

        public List<SubCategory>? GetAllSubCategories()
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            SubCategory subCategory;
            Employee emp;
            Category category;

            string cmdString = "SELECT Sub_CategoryID, Name, CategoryID ,AddedByEmployee from sub_category";

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    emp = new Employee(Convert.ToInt32(dr.GetValue(3).ToString()));
                    category = new Category();
                    category.ID = Convert.ToInt32(dr.GetValue(2).ToString());

                    subCategory = new SubCategory();
                    subCategory.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    subCategory.Name = dr.GetValue(1).ToString();
                    subCategory.AddedByEmployee = emp;

                    subCategories.Add(subCategory);
                }

                return subCategories;
            }
            catch (Exception)
            {
                return null;

            }
            finally { conn.Close(); }


        }

        public List<SubCategory>? GetSubCategoriesByCategoryID(Category category)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            SubCategory subCategory;
            Employee emp;

            string cmdString = "SELECT Sub_CategoryID, Name, CategoryID ,AddedByEmployee from sub_category WHERE CategoryID = @categoryID";

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                conn.Open();
                command.Parameters.AddWithValue("@categoryID", category.ID);
                MySqlDataReader dr = command.ExecuteReader();

                

                while (dr.Read())
                {
                    emp = new Employee(Convert.ToInt32(dr.GetValue(3).ToString()));
                   

                    subCategory = new SubCategory();
                    subCategory.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    subCategory.Name = dr.GetValue(1).ToString();
                    subCategory.AddedByEmployee = emp;
                    subCategory.Category = category;

                    subCategories.Add(subCategory);
                }

                return subCategories;
            }
            catch (Exception)
            {
                return null;

            }
            finally { conn.Close(); }


        }

        public string? getSubCategoryName(int id)
        {
            string cmdString = "SELECT Name from sub_category WHERE Sub_CategoryID = @id";
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
