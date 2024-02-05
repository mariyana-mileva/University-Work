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
using Desktop.Forms;
using Entities;

namespace Desktop
{
    public partial class LogInForm : Form
    {
        EmployeeAuthorizationManager employeeManager = new EmployeeAuthorizationManager();
        Employee employee;
        public LogInForm()
        {

            InitializeComponent();
            this.Text = "Log in";
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbId.Text.Length == 0 || tbPassword.Text.Length == 0)
                {
                    MessageBox.Show("Please fill in your email and password!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    employee = employeeManager.logInEmployee(tbId.Text, tbPassword.Text);
                    if (employee is not null)
                    {
                        MessageBox.Show("Logged in successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new Main(employee).Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong ID or password!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please connect to the vpn!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
