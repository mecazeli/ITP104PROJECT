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
            try
            {
                conn.Open();
                MessageBox.Show(message);

                string query = "SELECT * FROM department";

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader rd = command.ExecuteReader();

                DataTable departmentsTable = new DataTable();
                departmentsTable.Load(rd);

                dgvDepartments.DataSource = departmentsTable;

                dgvDepartments.Columns[0].HeaderText = "Id";
                dgvDepartments.Columns[1].HeaderText = "Department Name";
                dgvDepartments.Columns[2].HeaderText = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
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
                conn.Close();
            }
        }

        private void UpdateDepartment(string depID, string fieldName, string newValue)
        {

            try
            {
                conn.Open();

                string query = $"UPDATE department SET {fieldName} = @newValue WHERE departmentId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@newValue",newValue);
                command.Parameters.AddWithValue("@id",depID);

                command.ExecuteNonQuery();

            }catch(Exception ex)
            {
                MessageBox.Show("Error occured while updating the department " + ex.Message,"Database Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
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
            string depId = selectedRow.Cells["departmentId"].Value?.ToString();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                DataGridViewRow row = dgvDepartments.Rows[e.RowIndex];
                string columnName = dgvDepartments.Columns[e.ColumnIndex].Name;

                string depId = row.Cells["Id"].Value?.ToString();
                string newValue = row.Cells[e.ColumnIndex].Value?.ToString();

                if(string.IsNullOrEmpty(depId) || string.IsNullOrEmpty(newValue))
                {
                    MessageBox.Show("Invalid input. Please provide a valid value.","Input Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                string fieldToUpdate = null;

                  if(columnName == "departmentName")
                {
                    fieldToUpdate = "departmentName";
                }else if(columnName == "description")
                {
                    fieldToUpdate = "description";
                }
                else
                {
                    return;
                }

                string originalValue = row.Cells[e.ColumnIndex].Tag?.ToString();

                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want to update the {fieldToUpdate} to:\n\n{newValue}?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                 );

                if(dialogResult == DialogResult.Yes)
                {
                   UpdateDepartment(depId,fieldToUpdate,newValue);
                    MessageBox.Show($"{fieldToUpdate} updated successfully!","Update Successfully!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    ViewDepartments("Database updated successfully");
                }
                else
                {
                    row.Cells[e.ColumnIndex].Value = originalValue;
                }
              
            }catch(Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
