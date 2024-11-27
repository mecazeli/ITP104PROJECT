using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITP104PROJECT
{
    public partial class Dashboard : Form
    {
        public Admin admin;
        public Dashboard()
        {
            InitializeComponent();
            

            this.admin = admin;
        }

        //private void Dashboard_Load(object sender, EventArgs e)
        //{
        //    lblName.Text = admin.name;
        //}

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            Departments departmentsForm = new Departments(admin);
            departmentsForm.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employees employeesForm = new Employees();
            employeesForm.Show();
            this.Hide();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            Departments departmentsForm = new Departments(admin);
            departmentsForm.Show();
            this.Hide();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Employees employeesForm = new Employees();
            employeesForm.Show();
            this.Hide();
        }

        private void panelDasboard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
