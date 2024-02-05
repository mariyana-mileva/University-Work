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
    public partial class Main : Form
    {
        Employee employee;
        public Main(Employee loggedEmployee)
        {
       
            InitializeComponent();
            employee = loggedEmployee; 
        }

        private void OpenForm(Form child)
        {
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panelContent.Controls.Add(child);
            panelContent.Tag = child;
            child.BringToFront();
            child.Show();
        }


        private void lbCatalogue_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.CatalogueForm(employee));
        }

        private void lbOrders_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        private void lbProfile_Click(object sender, EventArgs e)
        {
            new ProfileFormEmployee(employee).Show();
        }

        private void pnProfile_Click(object sender, EventArgs e)
        {
            new ProfileFormEmployee(employee).Show();
        }
    }
}
