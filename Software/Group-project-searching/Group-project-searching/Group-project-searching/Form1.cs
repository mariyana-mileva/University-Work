using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group_project_searching
{
    public partial class Form1 : Form
    {
        DBHelper dbHelper = new DBHelper();
        List<Employees> employees = new List<Employees>();
        Employees employee;
        public SqlConnection sc = new SqlConnection(@"Data Source=LAPTOP-QD7GHJLS\SQLEXPRESS;Initial Catalog=WPC;Integrated Security=True");


        //isNumber = int.TryParse(tbSearch.Text, out value);
        public Form1()
        {
            InitializeComponent();

            dbHelper.FetchData(employees, employee);
         

            foreach (Employees e in employees)
            {
                lbEmployees.Items.Add($"({e.getEmployeeID}) | {e.getFName} {e.getLName}");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int value;
            lbEmployees.Items.Clear();
            if(int.TryParse(tbSearch.Text, out value))
            {
                dbHelper.SearchEmployeeByID(Convert.ToInt32(tbSearch.Text), employees, employee);
                foreach (Employees em in employees)
                {
                    lbEmployees.Items.Add($"({em.getEmployeeID}) | {em.getFName} {em.getLName}");
                }
            }
            else
            {
                dbHelper.SearchEmployee(tbSearch.Text, tbSearch.Text, employees, employee);
                foreach (Employees em in employees)
                {
                    lbEmployees.Items.Add($"({em.getEmployeeID}) | {em.getFName} {em.getLName}");
                }
            }

            
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lbEmployees.Items.Clear();
            dbHelper.FetchData(employees, employee);

           
            foreach (Employees emp in employees)
            {
                lbEmployees.Items.Add($"({emp.getEmployeeID}) | {emp.getFName} {emp.getLName}");
            }
        }
    }
}
