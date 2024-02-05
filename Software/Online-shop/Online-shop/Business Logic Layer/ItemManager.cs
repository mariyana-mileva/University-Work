using DataAccessLayer;
using Entities;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer
{
    public class ItemManager
    {
        ItemDB itemDB = new ItemDB();

        public Item CreateNewItem(string name, Category category, SubCategory subCategory, Employee emp, string unit, double price, MemoryStream ms)
        {
            return itemDB.CreateNewItemAndAddToDB(name, category, subCategory, emp, unit, price, ms);
        }
        public List<Item> getItemsDetails()
        {
            return itemDB.getItemsDetails();
        }
        public DataTable SearchItem(string name)
        {
            return itemDB.SearchItem(name);
        }
        public byte[]? RetrieveImageByte(Item item)
        {
            return itemDB.RetrieveImageByte(item);
        }
        public DataTable DisplayItemsTestInDataTable()
        {
            List<Item> items = itemDB.DisplayItems();
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemID");
            dt.Columns.Add("ItemPicture", typeof(byte[]));
            dt.Columns.Add("ItemName");
            dt.Columns.Add("CategoryName");
            dt.Columns.Add("Name");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Price");
            dt.Columns.Add("AddedByEmployee");

            foreach(var item in items)
            {
                var row = dt.NewRow();
                row["ItemID"] = item.ID;
                row["ItemPicture"] = RetrieveImageByte(item);
                row["ItemName"] = item.Name;
                row["CategoryName"] = item.CategoryName.Name;
                row["Name"] = item.SubCategoryName.Name;
                row["Unit"] = item.Unit;
                row["Price"] = item.Price;
                row["AddedByEmployee"] = item.AddedByEmployee.ID;

                dt.Rows.Add(row);
            }

            return dt;

        }

        public List<Item> DisplayAllItemsInList()
        {
            return itemDB.DisplayItems();
        }

        public void DeleteItem(Item item)
        {
            itemDB.DeleteItem(item);
        }
    }
}
