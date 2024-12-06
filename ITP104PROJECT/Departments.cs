using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP104PROJECT
{
    public partial class Departments : Form
    {
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        public MySqlConnection conn;
        public Admin admin = new Admin("Liezel T. Paciente", 30, "Female", "admin101", "password123");

        public Departments()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            //lblName.Text = string.IsNullOrEmpty(admin.name) ? "Welcome!" : admin.name;
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideProj.Click += new EventHandler(btnSide_Click);
            btnSettings.Click += new EventHandler(btnSide_Click);
            btnLogout.Click += new EventHandler(btnSide_Click);
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            lblName.Text = admin.name;
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


        private void btnView_Click(object sender, EventArgs e)
        {
            ViewDepartments("Database company connected successfully!");
        }

        private void btnAddDep_Click(object sender, EventArgs e)
        {
            AddingDepartment();
            ViewDepartments("Added Database Successfully!");
        }

        private void btnDelDep_Click(object sender, EventArgs e)
        {
            DeletingDepartment();
            ViewDepartments("Deleted Database Successfully!");
        }



        private void ViewDepartments(string message)
        {
            dgvDepartments.Rows.Clear();

            dgvDepartments.ColumnCount = 3;
            dgvDepartments.Columns[0].Name = "Id";
            dgvDepartments.Columns[1].Name = "Department Name";
            dgvDepartments.Columns[2].Name = "Description";

            try
            {
                conn.Open();
                MessageBox.Show(message);

                string query = "SELECT * FROM department";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader rd = command.ExecuteReader();

                DataTable departmentsTable = new DataTable();
                departmentsTable.Load(rd);

          
                if (departmentsTable.Rows.Count > 0)
                {
                    foreach (DataRow row in departmentsTable.Rows)
                    {
                        dgvDepartments.Rows.Add(
                            row["departmentId"],
                            row["departmentName"],
                            row["description"]
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No departments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void AddingDepartment()
        {
            string depName = txtDepName.Text.Trim();
            string depDescription = txtDescription.Text.Trim();

            if (!ValidateDepartmentInput(depName, depDescription))
            {
                return;
            }

            if (IsDepartmentNameExists(depName))
            {
                MessageBox.Show("This department name already exists. Please use a different department name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = "INSERT INTO department(departmentName, description) VALUES(@name, @description)";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@name", depName);
                command.Parameters.AddWithValue("@description", depDescription);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void DeletingDepartment()
        {
            if (dgvDepartments.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowCell = dgvDepartments.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvDepartments.Rows[selectedRowCell];
            string depId = selectedRow.Cells[0].Value?.ToString();

            if (string.IsNullOrEmpty(depId))
            {
                MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = "DELETE FROM department WHERE departmentId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@id", depId);

                command.ExecuteNonQuery();

                MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewDepartments("Department list updated after deletion.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateDepartment(string depId, string fieldName,string newValue)
        {
            try
            {
                conn.Open();

                string query = $"UPDATE department SET {fieldName} = @newValue WHERE departmentId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@newValue",newValue);
                command.Parameters.AddWithValue("@id", depId);

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occurred while updating the department: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

       
        public bool IsDepartmentNameExists(string depName)
        {
            try
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM department WHERE departmentName = @name";
                MySqlCommand command = new MySqlCommand(checkQuery, conn);
                command.Parameters.AddWithValue("@name", depName);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking the department name: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ValidateDepartmentInput(string depName, string depDescription)
        {
            if (string.IsNullOrEmpty(depName) || string.IsNullOrEmpty(depDescription))
            {
                MessageBox.Show("Both Department Name and Description are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dgvDepartments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex >= 0 && columnIndex >= 0)
            {
               
                string depID = dgvDepartments.Rows[rowIndex].Cells["Id"].Value?.ToString();
                string fieldName = dgvDepartments.Columns[columnIndex].HeaderText.Replace(" ", ""); 
                string newValue = dgvDepartments.Rows[rowIndex].Cells[columnIndex].Value?.ToString();

               
                if (string.IsNullOrEmpty(depID) || string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(newValue))
                {
                    MessageBox.Show("Invalid data. Please check the values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want to update the '{fieldName}' for Department ID {depID} to '{newValue}'?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        UpdateDepartment(depID, fieldName, newValue);
                        ViewDepartments("Department list updated.");
                        MessageBox.Show("Information updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
