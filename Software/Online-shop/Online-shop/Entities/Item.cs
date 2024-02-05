using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Item
    {
        private int id;
        private string name;
        private Category categoryName = new Category();
        private SubCategory subCategoryName = new SubCategory();
        private Employee addedByEmployee = new Employee();
        private string unit;
        private double price;

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Employee AddedByEmployee{ get { return addedByEmployee; } set { addedByEmployee = value; } }
        public Category CategoryName { get { return categoryName; } set { categoryName = value; } }
        public SubCategory SubCategoryName { get { return subCategoryName; } set { subCategoryName = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public double Price { get { return price;} set { price= value; } }
    }
}
