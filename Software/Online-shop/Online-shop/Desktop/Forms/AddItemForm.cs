using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using Entities;

namespace Desktop.Forms
{
    public partial class AddItemForm : Form
    {
        Employee employee;
        Category selectedCategory = new Category();
        SubCategory selectedSubCategory = new SubCategory();
        CatalogueForm parent;

        MemoryStream ms = new MemoryStream();
        
        List<Category> listOfCategories;
        List<SubCategory> listOfSubCategories;
        List<Item> listOfItems = new List<Item>();

        CategoryManager categoryManager = new CategoryManager();
        SubCateogryManager subCateogryManager= new SubCateogryManager();
        ItemManager itemManager = new ItemManager();




        public AddItemForm(Employee loggedEmployee, CatalogueForm _parent)
        {
            InitializeComponent();
            employee = loggedEmployee;
            parent = _parent;

        }

        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory(employee);
            addCategory.StartPosition = FormStartPosition.Manual;
            addCategory.Left = this.Left + (this.Width-10);
            addCategory.Top = this.addCategoryBtn.Top;

            addCategory.Show();
        }

        public void Clear()
        {
            tbName.Text = tbPrice.Text = tbUnit.Text = string.Empty;
        }


        public void UpdateInfo()
        {
            btnUploadPic.Text = "Update picture";
            btnSave.Text = "Update";
        }

        private void addSubCategoryBtn_Click(object sender, EventArgs e)
        {
            AddSubCategory addSubCategory = new AddSubCategory(employee);
            addSubCategory.Left = this.Left + (this.Width - 10);
            addSubCategory.Top = this.addCategoryBtn.Top;

            addSubCategory.Show();

        }

        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_MouseClick(object sender, MouseEventArgs e)
        {
            cbCategory.Items.Clear();
            listOfCategories = categoryManager.GetAllCategories();
            foreach (var category in listOfCategories)
            {
                cbCategory.Items.Add(category.Name);
            }
        }

        private void cbSubCategory_MouseClick(object sender, MouseEventArgs e)
        {
          
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Select category first!");
            }
            else
            {
                foreach (var category in listOfCategories)
                {

                    if (cbCategory.SelectedItem.ToString() == category.Name)
                    { 
                        listOfCategories = categoryManager.GetAllSubCategories(category);
                        foreach (var subCategory in listOfCategories)
                        {
                            cbSubCategory.Items.Add(subCategory.Name);
                        }
                        
                    }
                    
                }
            }

            
            listOfSubCategories = subCateogryManager.GetSubCategoriesByCategoryID(selectedCategory);

            foreach (var subCategory in listOfSubCategories)
            {
                cbSubCategory.Items.Add(subCategory.Name);
            }


        }

        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files | *.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(openFileDialog1.FileName);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var subCategory in listOfSubCategories)
            {
                if (cbSubCategory.SelectedItem.ToString() == subCategory.Name)
                {
                    selectedSubCategory = subCategory;
                }
            }
            try
            {
                pictureBox1.BackgroundImage.Save(ms, pictureBox1.BackgroundImage.RawFormat);
                itemManager.CreateNewItem(tbName.Text, selectedCategory, selectedSubCategory, employee, tbUnit.Text.ToLower(), Convert.ToDouble(tbPrice.Text), ms);

                MessageBox.Show("Item added succesfully");
                this.Close();
                parent.Display();

            }
            catch
            {
                MessageBox.Show("A problem occured!");
            }
            
        }
    }
}
