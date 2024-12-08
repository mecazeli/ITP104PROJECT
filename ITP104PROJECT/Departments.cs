using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP104PROJECT
{
    public partial class Departments : Form
    {
        public static string connection = "server=localhost; user=root; password=091203; database=company;";
        //public static string connection = "server=localhost; user=root; password=; database=company; port=3306";
        // public static string connection = "server=localhost; user=root; password=091203; database=company;";
        public MySqlConnection conn;
        public Admin _admin = new Admin();

        public Departments()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            //lblName.Text = string.IsNullOrEmpty(admin.name) ? "Welcome!" : admin.name;
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideEmp.Click += new EventHandler(btnSide_Click);
            btnSideProj.Click += new EventHandler(btnSide_Click);
            btnSettings.Click += new EventHandler(btnSide_Click);
            btnLogout.Click += new EventHandler(btnSide_Click);
        }

        public Departments(Admin admin) : this()
        {
            _admin = admin;
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            lblName.Text = _admin.name ;
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (clickedButton.Name == "btnDashboard")
                {
                    Dashboard dashboardForm = new Dashboard(_admin);
                    dashboardForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSideDep")
                {
                    Departments departmentsForm = new Departments(_admin);
                    departmentsForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSideEmp")
                {
                    Employees employeesForm = new Employees(_admin);
                    employeesForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSideProj")
                {
                    Project projectForm = new Project(_admin);
                    projectForm.Show();
                    this.Hide();
                }
                else if (clickedButton.Name == "btnSettings")
                {
                    Settings settingsForm = new Settings(_admin);
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

                        Login loginForm = new Login(_admin);
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
            conn.Close();
            dgvDepartments.Rows.Clear();

            dgvDepartments.ColumnCount = 3;
            dgvDepartments.Columns[0].Name = "Id";
            dgvDepartments.Columns[1].Name = "Department Name";
            dgvDepartments.Columns[2].Name = "Description";

            dgvDepartments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDepartments.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDepartments.Columns[2].Width = 200;
            dgvDepartments.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            try
            {
                conn.Open();

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

        private void UpdateDepartment()
        {
            if (dgvDepartments.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a department to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int selectedRowCell = dgvDepartments.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvDepartments.Rows[selectedRowCell];

            int depId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["Id"].Value);
            string newDepName = txtDepName.Text.Trim();
            string newDescription = txtDescription.Text.Trim();

            try
            {
                conn.Open();

               
                string fetchQuery = "SELECT departmentName, description FROM department WHERE departmentId = @id";
                MySqlCommand fetchCommand = new MySqlCommand(fetchQuery, conn);
                fetchCommand.Parameters.AddWithValue("@id", depId);

                using (MySqlDataReader reader = fetchCommand.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("Department not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string currentDepName = reader["departmentName"] != DBNull.Value
                                            ? reader["departmentName"].ToString().Trim()
                                            : string.Empty;

                    string currentDescription = reader["description"] != DBNull.Value
                                                 ? reader["description"].ToString().Trim()
                                                 : string.Empty;

                    reader.Close();

                   
                    if (currentDepName == newDepName && currentDescription == newDescription)
                    {
                        MessageBox.Show("No changes detected to update.", "No Update Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

              
                    DialogResult dialogResult = MessageBox.Show(
                        $"Are you sure you want to update Department ID {depId}?\n\n" +
                        $"Old Name: {currentDepName}\nNew Name: {newDepName}\n\n" +
                        $"Old Description: {currentDescription}\nNew Description: {newDescription}",
                        "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Update cancelled by the user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bool isUpdated = UpdateDepartmentQuery(depId, newDepName, newDescription);
                    if (isUpdated)
                    {
                        MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewDepartments("Department list updated after modification.");
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Please check the input and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private bool UpdateDepartmentQuery(int departmentId, string newName, string newDescription)
        {
            using (MySqlConnection updateConn = new MySqlConnection(conn.ConnectionString))
            {
                try
                {
                    updateConn.Open();

                    string updateQuery = "UPDATE department SET departmentName = @newName, description = @newDesc WHERE departmentId = @id";

                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, updateConn);
                    updateCommand.Parameters.AddWithValue("@newName", newName);
                    updateCommand.Parameters.AddWithValue("@newDesc", newDescription);
                    updateCommand.Parameters.AddWithValue("@id", departmentId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the department: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDepartment();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            SearchDepartment(searchTerm);
        }

        private void SearchDepartment(string searchTerm)
        {
            dgvDepartments.Rows.Clear();

            // Convert the search term to lower case for case-insensitive comparison
            string lowerSearchTerm = searchTerm.ToLower();

            try
            {
                conn.Open();

                // Use a parameterized query to prevent SQL injection
                string query = @"
            SELECT 
                departmentId, departmentName
            FROM department";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Check if the department name contains the search term (case-insensitive)
                            if (reader["departmentName"].ToString().ToLower().Contains(lowerSearchTerm))
                            {
                                dgvDepartments.Rows.Add(
                                    reader["departmentId"],
                                    reader["departmentName"]
                                );
                            }
                        }
                    }
                }

                if (dgvDepartments.Rows.Count == 0)
                {
                    MessageBox.Show("No departments found matching the search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
