using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using Entities;

namespace Desktop.Forms
{
    public partial class AddCategory : Form
    {
        CategoryManager categoryManager = new CategoryManager();

        Employee employee;
        public AddCategory(Employee loggedEmployee)
        {
            InitializeComponent();
            employee = loggedEmployee;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (char.IsUpper(tbCategoryName.Text[0]) == true)
            {
                try
                {
                    if (categoryManager.checkForRepeatingCategory(tbCategoryName.Text) != true)
                    {
                        categoryManager.CreateNewCategory(tbCategoryName.Text, employee);
                        MessageBox.Show("Categort added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("This category alreadt exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbCategoryName.Clear();
                    }

                }
                catch
                {
                    MessageBox.Show("A problem occured!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {

                    
                }
            }
            else
            {
                MessageBox.Show("The first letter of the category's name should be capital!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }
    }
}
