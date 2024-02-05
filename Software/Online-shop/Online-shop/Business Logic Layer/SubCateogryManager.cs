using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class SubCateogryManager
    {
        SubCategoryDB subCategoryDb = new SubCategoryDB();
        public SubCategory CreateNewSubCategory(string name, Employee emp, Category category)
        {
            return subCategoryDb.CreateNewSubCategoryAndAddToDB(name, emp, category);
        }

        public bool? checkForRepeatingSubCategory(string name)
        {
            return subCategoryDb.checkForRepeatingSubCategory(name);
        }

        public List<SubCategory>? GetAllSubCategories()
        {
            return subCategoryDb.GetAllSubCategories();
        }

        public List<SubCategory>? GetSubCategoriesByCategoryID(Category category)
        {
            return subCategoryDb.GetSubCategoriesByCategoryID(category);
        }
        public string? getSubCategoryName(int id)
        {
            return subCategoryDb.getSubCategoryName(id);
        }
    }
}
