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
        public Admin admin;

        public Departments(Admin admin)
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            this.admin = admin;
            lblName.Text = string.IsNullOrEmpty(admin.name) ? "Welcome!" : admin.name;
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            lblName.Text = admin.name;
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

        //private void btnUpdDep_Click(object sender, EventArgs e)
        //{
        //    UpdatingDepartment();
        //    ViewDepartments("Updated Database Successfully!");
        //}

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

        //private void UpdatingDepartment()
        //{
        //    if (dgvDepartments.SelectedCells.Count == 0)
        //    {
        //        MessageBox.Show("Please select a department to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    int selectedRowCell = dgvDepartments.SelectedCells[0].RowIndex;
        //    DataGridViewRow selectedRow = dgvDepartments.Rows[selectedRowCell];
        //    string depId = selectedRow.Cells["departmentId"].Value?.ToString();

        //    if (string.IsNullOrEmpty(depId))
        //    {
        //        MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    string depName = txtDepName.Text.Trim();
        //    string depDescription = txtDescription.Text.Trim();

        //    try
        //    {
        //        conn.Open();

        //        string query = "UPDATE department SET departmentName = @name, description = @description WHERE departmentId = @id";
        //        MySqlCommand command = new MySqlCommand(query, conn);

        //        command.Parameters.AddWithValue("@id", depId);
        //        command.Parameters.AddWithValue("@name", depName);
        //        command.Parameters.AddWithValue("@description", depDescription);

        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

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

        private void dgvDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
