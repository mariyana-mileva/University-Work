using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ISubCategoryDB
    {
        bool? checkForRepeatingSubCategory(string name);
        int? getSubCategoryID(string name);
        SubCategory CreateNewSubCategoryAndAddToDB(string name, Employee emp, Category category);
        List<SubCategory>? GetAllSubCategories();
        List<SubCategory>? GetSubCategoriesByCategoryID(Category category);
    }
}
