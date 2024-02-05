using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer.EmployeeManagers;

namespace Desktop.Forms
{
    public partial class ProfileFormEmployee : Form
    {
        Employee employee;
        EmployeeManager empManager;
        MemoryStream ms = new MemoryStream();

        public ProfileFormEmployee(Employee loggedEmployee)
        {
            InitializeComponent();
            employee = loggedEmployee;
            empManager = new EmployeeManager();

            tbID.Text = employee.ID.ToString();
            tbFName.Text = employee.FirstName;
            tbLName.Text = employee.LastName;
            tbEmail.Text = employee.Email;

            if(empManager.RetrieveImage(ms, employee) == null)
            {
                return;
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromStream(empManager.RetrieveImage(ms, employee));
            }
            
             
        }

    
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            pictureBox1.BackgroundImage.Save(ms, pictureBox1.BackgroundImage.RawFormat);

            if(tbEmail.Text.Length > 0 && tbFName.Text.Length > 0 && tbLName.Text.Length > 0)
            {
                try
                {
                    empManager.updateEmployee(tbEmail.Text, tbFName.Text, tbLName.Text, employee);
                    empManager.UploadImage(ms, employee);

                   
                    MessageBox.Show("Information updated succesfully");
                }
                catch
                {
                    MessageBox.Show("A problem occured!");
                }
                
            }
            else
            {
                MessageBox.Show("Please fill all information");
            }
             
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files | *.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(openFileDialog1.FileName);
  
            }
        }
    }
}
