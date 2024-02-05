using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entities;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;

namespace DataAccessLayer
{
    public class ItemDB: IitemDB
    {
        MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi482676;Database=dbi482676;Pwd=12345;");

        public int? getItemID(string name)
        {
            try
            {
                int id = 0;
                string cmdString = "SELECT ItemID from items where ItemName = @name";
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

        public Item CreateNewItemAndAddToDB(string name, Category category, SubCategory subCategory, Employee emp, string unit, double price, MemoryStream ms)
        {
            Item item = new Item();

            string cmdString = "INSERT INTO items(ItemName, CategoryID, SubCategoryID, AddedByEmployee, Unit, Price, ItemPicture) Values(@name, @category, @subCategory, @emp, @unit, @price, @img)";

            int id = 0;

            try
            {
                MySqlCommand command = new MySqlCommand(cmdString, conn);
                byte[] img = ms.ToArray();

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@category", category.ID);
                command.Parameters.AddWithValue("@subCategory", subCategory.ID);
                command.Parameters.AddWithValue("@emp", emp.ID);
                command.Parameters.AddWithValue("@unit", unit);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@img", img);

                conn.Open();



                command.ExecuteNonQuery();

                id = Convert.ToInt32(getItemID(name));

                item.ID = id;
                item.Name = name;
                item.CategoryName = category;
                item.SubCategoryName = subCategory;
                item.AddedByEmployee.ID = emp.ID;
                item.Unit = unit;
                item.Price = price;

                

                return item;

            }
            catch (Exception)
            {
                return null;
                throw;

            }
            finally { conn.Close(); }



        }



        public List<Item> getItemsDetails()
        {
            string cmdString = "SELECT ItemID, ItemPicture, ItemName, CategoryID, SubCategoryID, Unit, Price, AddedByEmployee from items";
            List<Item> items = new List<Item>();
            
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdString, conn);

                conn.Open();

                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Item item = new Item();
                    item.ID = Convert.ToInt32(dr.GetValue(0));
                    item.Name = dr.GetString(2).ToString();
                    item.CategoryName.ID = dr.GetInt32(3);
                    item.SubCategoryName.ID = dr.GetInt32(4);
                    item.Unit = dr.GetString(5).ToString();
                    item.Price = Convert.ToDouble(dr.GetDouble(6));
                    item.AddedByEmployee.ID = Convert.ToInt32(dr.GetInt32(7));

                    items.Add(item);
                }
                

                return items;

            }
            catch(Exception ) 
            {
                throw;
            }
            finally { conn.Close(); }

        }

        //public DataTable DisplayItems()
        //{
        //    try
        //    {
        //        string sql = "SELECT i.ItemID, i.ItemPicture,  i.ItemName, c.CategoryName, sc.Name, i.Unit, i.Price, i.AddedByEmployee FROM items as i INNER JOIN category as c ON i.CategoryID = c.CategoryID INNER JOIN sub_category as sc ON i.SubCategoryID = sc.Sub_CategoryID";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
                
        //        conn.Open();
                
        //        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
                
        //        adp.Fill(dt);
        //        return dt;


        //    }catch(Exception )
        //    {
        //        throw;
        //    }
        //    finally { conn.Close(); }

        //}

        public DataTable SearchItem(string name)
        {
            try
            {
                string sql = "SELECT i.ItemID, i.ItemPicture,  i.ItemName, c.CategoryName, sc.Name, i.Unit, i.Price, i.AddedByEmployee FROM items as i INNER JOIN category as c ON i.CategoryID = c.CategoryID INNER JOIN sub_category as sc ON i.SubCategoryID = sc.Sub_CategoryID WHERE i.ItemName LIKE '%" + name + "%'";

                MySqlCommand command = new MySqlCommand(sql, conn);

                conn.Open();

                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();

                adp.Fill(dt);
                return dt;

            }
            catch(Exception )
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public byte[]? RetrieveImageByte(Item item)
        {
            try
            {
                string cmdString = "SELECT ItemPicture FROM items WHERE ItemID = @id";
                byte[]? img = null;

                MySqlCommand command = new MySqlCommand(cmdString, conn);

                conn.Open();

                command.Parameters.AddWithValue("@id", item.ID);

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

                return img;

            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }

        }
        public List<Item> DisplayItems()
        {
            try
            {
                
                List<Item> items = new List<Item>();

                string sql = "SELECT i.ItemID, i.ItemName, c.CategoryName, sc.Name, i.Unit, i.Price, i.AddedByEmployee FROM items as i INNER JOIN category as c ON i.CategoryID = c.CategoryID INNER JOIN sub_category as sc ON i.SubCategoryID = sc.Sub_CategoryID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Item item = new Item();
                    item.ID = Convert.ToInt32(dr.GetValue(0));
                    item.Name = dr.GetString(1).ToString();
                    item.CategoryName.Name = dr.GetString(2).ToString();
                    item.SubCategoryName.Name = dr.GetString(3).ToString();
                    item.Unit = dr.GetString(4).ToString();
                    item.Price = Convert.ToDouble(dr.GetDouble(5));
                    item.AddedByEmployee.ID = dr.GetInt32(6);

                    items.Add(item);
                }

                return items;


            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }

        }


        public void UpdateItem(string name, Category category, SubCategory subCategory, Employee emp, string unit, double price, MemoryStream ms)
        {

        }

        public void DeleteItem(Item item)
        {
            string sql = "DELETE FROM items WHERE ItemID = @id";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@id", item.ID);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
                
            }
            finally { conn.Close(); }

        }
    }


}
