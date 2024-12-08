using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP104PROJECT
{
    public partial class Update : Form
    {
        public Employees employees;
        string connection = "server=localhost; user=root; password=091203; database=company;";

        public Update(Employees employeeForm)
        {
            InitializeComponent();
            LoadDepartments();
            employees = employeeForm;
        }

        private void Update_Load(object sender, EventArgs e)
        {
            // Any additional initialization can be done here
        }

        private void LoadDepartments()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT departmentId, departmentName FROM department";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable departments = new DataTable();
                            departments.Load(reader);
                            cmbDepartment.DataSource = departments;
                            cmbDepartment.DisplayMember = "departmentName";
                            cmbDepartment.ValueMember = "departmentId";
                            cmbDepartment.SelectedIndex = -1;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            int empId;
            if (!int.TryParse(txtEmpId.Text, out empId))
            {
                MessageBox.Show("Please enter a valid Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT email, salary, position, departmentId FROM employee WHERE employeeId = @empId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empId", empId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmail.Text = reader["email"].ToString();
                                txtSalary.Text = reader["salary"].ToString();
                                txtPosition.Text = reader["position"].ToString();
                                cmbDepartment.SelectedValue = reader["departmentId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Employee not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching employee details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RefreshEmployeeGrid(string message = "")
        {
            if (employees != null)
            {
                employees.ViewEmployees(); // Call the method in the Employees form to refresh the grid
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int empId;
            if (!int.TryParse(txtEmpId.Text, out empId))
            {
                MessageBox.Show("Please enter a valid Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newEmail = txtEmail.Text.Trim();
            decimal newSalary;
            if (!decimal.TryParse(txtSalary.Text, out newSalary))
            {
                MessageBox.Show("Please enter a valid salary.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPosition = txtPosition.Text.Trim();
            object newDepartment = cmbDepartment.SelectedValue;

            if (newDepartment == null)
            {
                MessageBox.Show("Please select a department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE employee SET email = @newEmail, salary = @newSalary, position = @newPosition, departmentId = @newDepartment WHERE employeeId = @empId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newEmail", newEmail);
                        cmd.Parameters.AddWithValue("@newSalary", newSalary);
                        cmd.Parameters.AddWithValue("@newPosition", newPosition);
                        cmd.Parameters.AddWithValue("@newDepartment", newDepartment);
                        cmd.Parameters.AddWithValue("@empId", empId);
                        

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshEmployeeGrid("Employee data refreshed after update."); // Pass success message
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please check the details and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}



