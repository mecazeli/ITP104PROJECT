using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP104PROJECT
{
    public partial class Employees : Form
    {

        public Admin admin;
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        public MySqlConnection conn;
        public Employees()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideProj.Click += new EventHandler(btnSide_Click);
            btnSettings.Click += new EventHandler(btnSide_Click);
            btnLogout.Click += new EventHandler(btnSide_Click);
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (clickedButton.Name == "btnDashboard")
                {
                    Dashboard dashboardForm = new Dashboard();
                    dashboardForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSideDep")
                {
                    Departments departmentsForm = new Departments();
                    departmentsForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSideEmp")
                {
                    Employees employeesForm = new Employees();
                    employeesForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSideProj")
                {
                    Project projectForm = new Project();
                    projectForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSettings")
                {
                    Settings settingsForm = new Settings();
                    settingsForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnLogout")
                {
                    var result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {

                        MessageBox.Show("You are now logging out. Please wait...",
                                 "Logging Out",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                        this.Hide();

                        Login loginForm = new Login();
                        loginForm.Show();
                    }

                }
            }
         }

     

        private void Employees_Load(object sender, EventArgs e)
        {

        }


        private void ViewEmployees()
        {
            dgvEmployees.Rows.Clear();

            dgvEmployees.ColumnCount = 9;
            dgvEmployees.Columns[0].Name = "Employee ID";
            dgvEmployees.Columns[1].Name = "Employee Name";
            dgvEmployees.Columns[2].Name = "Age";
            dgvEmployees.Columns[3].Name = "Gender";
            dgvEmployees.Columns[4].Name = "Address";
            dgvEmployees.Columns[5].Name = "Email";
            dgvEmployees.Columns[6].Name = "Position";
            dgvEmployees.Columns[7].Name = "Date Hired";
            dgvEmployees.Columns[8].Name = "Salary";
            dgvEmployees.Columns.Add("Department", "Department Name"); 

            try
            {
                conn.Open();

   
                string query = @"
                SELECT 
                   e.employeeId, e.employeeName, e.age, e.gender, e.address,
                   e.email, e.position, e.datehired, e.salary, d.departmentName
                FROM employee e
                JOIN department d ON e.departmentId = d.departmentId;
                ";

               
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable employeesTable = new DataTable();
                dataAdapter.Fill(employeesTable);

              
                if (employeesTable.Rows.Count > 0)
                {
                   
                    foreach (DataRow row in employeesTable.Rows)
                    {
                       
                        string formattedSalary = "₱" + Convert.ToDecimal(row["salary"]).ToString("N2");

                      
                        dgvEmployees.Rows.Add(
                            row["employeeId"],
                            row["employeeName"],
                            row["age"],
                            row["gender"],
                            row["address"],
                            row["email"],
                            row["position"],
                            row["datehired"],
                            formattedSalary, 
                            row["departmentName"] 
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No employees found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
           
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }




        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            ViewEmployees();
        }
    }

}

