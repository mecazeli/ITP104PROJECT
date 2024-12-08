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
        public Admin _admin;

        public Dashboard()
        {
            InitializeComponent();
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideProj.Click += new EventHandler(btnSide_Click);
            btnSettings.Click += new EventHandler(btnSide_Click);
            btnLogout.Click += new EventHandler(btnSide_Click);
        }


        public Dashboard(Admin admin) : this()
        {

            _admin = admin;
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                switch (clickedButton.Name)
                {
                    case "btnDashboard":
                        MessageBox.Show("You are already on the Dashboard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                       
                    case "btnSideDep":
                        Departments departmentsForm = new Departments(_admin);
                        departmentsForm.Show();
                        this.Hide();
                        break;

                    case "btnSideProj":
                        Project projectForm = new Project(_admin);
                        projectForm.Show();
                        this.Hide();
                        break;

                    case "btnSettings":
                        // Pass _admin to the Settings form
                        Settings settingsForm = new Settings(_admin);
                        settingsForm.Show();
                        this.Hide();
                        break;

                    case "btnLogout":
                        var result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Logging out...", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Login loginForm = new Login(_admin);
                            loginForm.Show();
                        }
                        break;
                }
            }
        }
<<<<<<< HEAD

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            Departments departmentForm = new Departments();
            this.Hide();
            departmentForm.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Employees employeesForm = new Employees();
            this.Hide();
            employeesForm.Show();
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            Project projectForm = new Project();
            this.Hide();
            projectForm.Show();
        }
=======
>>>>>>> 8f88a6b2a9807e6a42c8803cf417aa2dc19b7443
    }
}
