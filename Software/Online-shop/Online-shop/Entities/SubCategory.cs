using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubCategory
    {
        private int id;
        private string name;
        private Category categoryID;
        private Employee addedByEmployee;


        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Employee AddedByEmployee { get { return addedByEmployee; } set { addedByEmployee = value; } }

        public Category Category { get { return categoryID; } set { categoryID = value; } }
    }
}
