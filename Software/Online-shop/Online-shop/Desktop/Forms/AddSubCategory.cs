using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
namespace Desktop.Forms
{
    public partial class AddSubCategory : Form
    {
        CategoryManager categoryManager = new CategoryManager();
        SubCateogryManager subCateogryManager = new SubCateogryManager();
        List<Category> listOfCategories = new List<Category>();
        Employee employee;
        Category selectedCategory = new Category();

        public AddSubCategory(Employee loggedEmployee)
        {
            InitializeComponent();
            employee = loggedEmployee;

            listOfCategories = categoryManager.GetAllCategories();

            foreach (var category in listOfCategories)
            {
                cbCategory.Items.Add(category.Name);
            }
        }

        private void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            foreach(var category in listOfCategories) 
            {
                if(cbCategory.SelectedItem.ToString() == category.Name)
                {
                    selectedCategory = category;
                }
            }
            if (char.IsUpper(subCategoryName.Text[0]) == true)
            {
                try
                {
                    if (subCateogryManager.checkForRepeatingSubCategory(subCategoryName.Text) != true)
                    {
                        subCateogryManager.CreateNewSubCategory(subCategoryName.Text, employee, selectedCategory);
                        MessageBox.Show("Sub-category added succesfully!");
                        this.Hide();
                    }
                    else if (subCateogryManager.checkForRepeatingSubCategory(subCategoryName.Text) == true)
                    {
                        MessageBox.Show("This category already exists");
                        subCategoryName.Clear();
                    }

                }
                catch
                {
                    MessageBox.Show("A problem occured!");
                }

            }
            else
            {
                MessageBox.Show("First letter of category name should be uppercase!");
            }

        }
    }
}
