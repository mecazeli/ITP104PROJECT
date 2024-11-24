using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Org.BouncyCastle.Ocsp;

namespace ITP104PROJECT
{
    public partial class Departments : Form
    {
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        //public static string connection = "server=localhost; user=root; password=; database=company; port=3306";
        public MySqlConnection conn;
        public Admin admin;
        public Departments(Admin admin)
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            this.admin = admin;
        }

        private void txtDepName_TextChanged(object sender, EventArgs e)
        {

        }
        private void Departments_Load(object sender, EventArgs e)
        {
            lblName.Text = admin.name;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewDepartments("Database company connected successfully!");
        }

        private void dataGridViewDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void btnUpdDep_Click(object sender, EventArgs e)
        {
            UpdatingDepartment();
            ViewDepartments("Updated Database Successfully!");
        }


        //method for showing departments
        private void ViewDepartments(String message)
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


        //method for adding department
        private void AddingDepartment()
        {
            string depName = txtDepName.Text.Trim();
            string depDescription = txtDescription.Text.Trim();

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

        // method for update department 
        private void UpdatingDepartment()
        {
            int selectedRowCell = dgvDepartments.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvDepartments.Rows[selectedRowCell];
           
            if (selectedRow.Cells["departmentId"].Value == DBNull.Value || dgvDepartments.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a department to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string depId = selectedRow.Cells["departmentId"].Value.ToString();
            string depName = txtDepName.Text.Trim();
            string depDescription = txtDescription.Text.Trim();

            try
            {
                conn.Open();

                string query = "UPDATE department SET departmentName = @name, description = @description WHERE departmentId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@id", depId);
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

        // method for delete 
        private void DeletingDepartment()
        {
            int selectedRowCell = dgvDepartments.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvDepartments.Rows[selectedRowCell];
           
            if (selectedRow.Cells["departmentId"].Value == DBNull.Value || dgvDepartments.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            string depId = selectedRow.Cells["departmentId"].Value.ToString();

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

       
    }
}
