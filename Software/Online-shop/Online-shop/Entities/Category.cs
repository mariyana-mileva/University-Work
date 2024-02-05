using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        private int id;
        private string name;
        private int? parentId;
        private Employee addedByEmployee;
        private List<Category> categories;


        public Category()
        {
            this.parentId = null;
            //addedByEmployee = new Employee();
            //categories = new List<Category>();
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int? ParentID { get { return parentId; } set { parentId = value; } }
        public Employee AddedByEmployee { get { return addedByEmployee; } set { addedByEmployee = value; } }
        public List<Category> Categories { get { return categories; } set { categories = value; } }
    }
}
