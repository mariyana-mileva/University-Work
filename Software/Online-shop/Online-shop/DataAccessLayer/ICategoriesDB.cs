using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICategoriesDB
    {
        bool? checkForRepeatingCategory(string name);
        int? getCategoryID(string name);
        Category CreateNewCategoryAndAddToDB(string name, Employee emp);
        List<Category>? GetAllCategories();
        List<Category>? GetAllSubCategories(Category category);
    }
}
