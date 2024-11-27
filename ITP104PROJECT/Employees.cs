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
    public partial class Employees : Form
    {

        public Admin admin;
        public Employees()
        {
            InitializeComponent();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSideDep_Click(object sender, EventArgs e)
        {
            Departments departmentsForm = new Departments(admin);
            departmentsForm.Show();
            this.Hide();
        }

        private void btnSideEmp_Click(object sender, EventArgs e)
        {
            Employees employeesForm = new Employees();
            employeesForm.Show();
            this.Hide();
        }

        private void btnSideProj_Click(object sender, EventArgs e)
        {
            Project projectForm = new Project();
            projectForm.Show();
            this.Hide();
        }
    }
}
