using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace ITP104PROJECT
{
    public partial class Project : Form
    {

        public static string connection = "server=localhost; user=root; password=091203; database=company;";
        //public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        public MySqlConnection conn;
        public Admin admin = new Admin("Liezel T. Paciente", 30, "Female", "admin101", "password123");

        public Project()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideEmp.Click += new EventHandler(btnSide_Click);
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



        private void Project_Load(object sender, EventArgs e)
        {
            label4.Text = admin.name;
            ViewProjectAndTasks("View Project and Tasks");
            PopulateDepartmentComboBox();
            PopulateEmployee();
        }

        private void PopulateDepartmentComboBox()
        {
            try
            {
                string query = "SELECT departmentId, departmentName FROM department";
                DataTable dep = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dep);
                    }
                }

                cbDepartment.DataSource = dep;
                cbDepartment.ValueMember = "departmentId";
                cbDepartment.DisplayMember = "departmentName";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void PopulateEmployee()
        {
            try
            {
                string query = "SELECT e.employeeId, e.employeeName FROM employee e";
                DataTable employees = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(employees);
                    }
                }
                cbEmployee.DataSource = employees;
                cbEmployee.ValueMember = "employeeId";
                cbEmployee.DisplayMember = "employeeName";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error populating employee comboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ViewProjectAndTasks(string message)
        {;
            dgvProject.Rows.Clear();
            dgvProject.Columns.Clear();

            dgvProject.ColumnCount = 7;
            dgvProject.Columns[0].Name = "Project ID";
            dgvProject.Columns[1].Name = "Project Name";
            dgvProject.Columns[2].Name = "Project Start Date";
            dgvProject.Columns[3].Name = "Project End Date";
            dgvProject.Columns[4].Name = "Task ID";
            dgvProject.Columns[5].Name = "Task Name";
            dgvProject.Columns[6].Name = "Employee ID";

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Project Status";
            statusColumn.HeaderText = "Project Status";
            statusColumn.Items.AddRange("Pending", "In Progress", "Completed");
            dgvProject.Columns.Add(statusColumn);


            try
            {
               
                conn.Open();
                MessageBox.Show(message);

               
                string query = @"
             SELECT 
                p.projectId,
                p.projectName,
                p.startDate AS ProjectStartDate,
                p.endDate AS ProjectEndDate,
                t.taskId,
                t.taskName,
                t.employeeId,
                p.status AS projectStatus
            FROM 
                project p
            LEFT JOIN 
                task t ON p.projectId = t.projectId;
           ";

              
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

              
                DataTable projectTaskTable = new DataTable();
                projectTaskTable.Load(reader);

              
                if (projectTaskTable.Rows.Count > 0)
                {
                    foreach (DataRow row in projectTaskTable.Rows)
                    {
                        
                        int rowIndex = dgvProject.Rows.Add(
                            row["projectId"],
                            row["projectName"],
                            row["ProjectStartDate"],
                            row["ProjectEndDate"],
                            row["taskId"] != DBNull.Value ? row["taskId"] : null,
                            row["taskName"] != DBNull.Value ? row["taskName"] : null,
                            row["employeeId"] != DBNull.Value ? row["employeeId"] : null
                        );

                       
                        dgvProject.Rows[rowIndex].Cells["Project Status"].Value = row["projectStatus"] != DBNull.Value
                            ? row["projectStatus"].ToString()
                            : "Pending";
                    }
                }
                else
                {
                    MessageBox.Show("No projects found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void AddProject()
        {
            string projName = txtProjName.Text.Trim(); 
            string selectedDepId = cbDepartment.SelectedValue.ToString(); 
            DateTime targetDate = projectTargetDate.Value;

            if (string.IsNullOrEmpty(projName) || string.IsNullOrEmpty(selectedDepId))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                         INSERT INTO project (projectName, departmentId, startDate, endDate, status)
                         VALUES (@projectName, @departmentId, @startDate, @endDate, 'Pending');";


            }
            catch (Exception ex)
            {

            }
        }
        private void DeleteProejct()
        {

        }
        private void UpdateProject()
        {

        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateProject_Click(object sender, EventArgs e)
        {

        }


        // +==============================================================+

        private void AddTask()
        {

        }
        private void DeleteTask()
        {

        }
        private void UpdateTask()
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {

        }
    }
}
