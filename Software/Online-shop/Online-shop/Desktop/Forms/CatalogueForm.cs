using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using Entities;



namespace Desktop.Forms
{
    public partial class CatalogueForm : Form
    {
        Employee employee;
        ItemManager itemManager = new ItemManager();
        AddItemForm addItemForm;
        List<Item> listOfItems;

        public void dataGridViewSettings()
        {
            Image.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvItems.RowTemplate.Height = 100;
            dgvItems.AllowUserToAddRows = false;
        }

        public void FillList()
        {
            listOfItems = itemManager.DisplayAllItemsInList();
        }

        public void Display()
        {
            dgvItems.DataSource = itemManager.DisplayItemsTestInDataTable();
            FillList();
            
        }

        public void Search()
        {
            dgvItems.DataSource = itemManager.SearchItem(tbSearch.Text);
        }

        


        public CatalogueForm(Employee loggedEmp)
        {
            InitializeComponent();
            dataGridViewSettings();

            employee = loggedEmp;
        }

        public CatalogueForm(Employee loggedEmp, List<Item> items)
        {
            InitializeComponent();
            dataGridViewSettings();

            employee = loggedEmp;
            listOfItems = items;
            
        }

       

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CatalogueForm_Shown(object sender, EventArgs e)
        {
            Display();
        }


        private void lbAddItem_Click(object sender, EventArgs e)
        {
            addItemForm = new AddItemForm(employee, this);
            addItemForm.Show();
        }

        private void pnAddItem_Click(object sender, EventArgs e)
        {
            addItemForm = new AddItemForm(employee, this);
            addItemForm.Show();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

      
        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Test
            string selectedID = dgvItems.Rows[e.RowIndex].Cells["itemID"].Value.ToString();
            if (e.ColumnIndex == 3)
            {
                foreach(Item item in listOfItems)
                {
                    if (item.ID == Convert.ToInt64(selectedID))
                    {
                        MessageBox.Show(item.ID.ToString() + item.Name + item.CategoryName.Name + item.SubCategoryName.Name);
          
                    }
                   
                }
               
            }


            if (e.ColumnIndex == 0)
            {
                AddItemForm addItemForm = new AddItemForm(employee, this);
                addItemForm.Show();

            }else if(e.ColumnIndex == 1)
            {
                string selectedItemID = dgvItems.Rows[e.RowIndex].Cells["itemID"].Value.ToString();
                foreach (Item item in listOfItems)
                {
                    if (item.ID == Convert.ToInt64(selectedID))
                    {
                        try
                        {
                            itemManager.DeleteItem(item);
                            listOfItems.Remove(item);
                            MessageBox.Show("Deleted");
                        }
                        catch
                        {
                            MessageBox.Show("Couldn't delete the item!");
                        }
                       
                        
                        
                    }

                }
                
            }
        }

        private void CatalogueForm_Load(object sender, EventArgs e)
        {
            FillList();
        }
    }
}
