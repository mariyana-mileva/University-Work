using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IitemDB
    {
        int? getItemID(string name);
        Item CreateNewItemAndAddToDB(string name, Category category, SubCategory subCategory, Employee emp, string unit, double price, MemoryStream ms);
        List<Item> getItemsDetails();

        List<Item> DisplayItems();
        byte[]? RetrieveImageByte(Item item);
        DataTable SearchItem(string name);
        void DeleteItem(Item item);

        void UpdateItem(string name, Category category, SubCategory subCategory, Employee emp, string unit, double price, MemoryStream ms);
    }
}
