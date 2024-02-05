using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
    
    public class CategoryManager
    {
        ICategoriesDB categoiesDb = new CategoryDB();

        public Category CreateNewCategory(string name, Employee emp)
        {
            return categoiesDb.CreateNewCategoryAndAddToDB(name, emp);
        }

        public bool? checkForRepeatingCategory(string name)
        {
            return categoiesDb.checkForRepeatingCategory(name);
        }

        public List<Category>? GetAllCategories()
        {
            return categoiesDb.GetAllCategories();
        }


        public List<Category>? GetAllSubCategories(Category category)
        {
            return categoiesDb.GetAllSubCategories(category);
        }
        //public string? getCategoryName(int id)
        //{
        //    return categoiesDb.getCategoryName(id);
        //}
    }
}
