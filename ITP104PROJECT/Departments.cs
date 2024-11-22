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

namespace ITP104PROJECT
{
    public partial class Departments : Form
    {
        public static string connection = "server=localhost; user=root; password=liezel11; database=company";
        public MySqlConnection conn;
        public Admin admin;
        public Departments(Admin admin)
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            this.admin = admin;
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            lblName.Text = admin.name;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Database company connected successfully!");

                string query = "SELECT * FROM department";

                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader rd = command.ExecuteReader();

                DataTable departmentsTable = new DataTable();
                departmentsTable.Load(rd);

                dataGridViewDepartments.DataSource = departmentsTable;

                dataGridViewDepartments.Columns[0].HeaderText = "Id";
                dataGridViewDepartments.Columns[1].HeaderText = "Department Name";
                dataGridViewDepartments.Columns[2].HeaderText = "Description";


            }catch(Exception ex)
            {
                MessageBox.Show("Cannot connect to the database: " + ex.Message, "Database Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
           

        }

        private void dataGridViewDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddDep_Click(object sender, EventArgs e)
        {
            AddingDepartment();
        }


        //method for adding department
        private void AddingDepartment()
        {
            string depName = txtDepName.Text.Trim();
            string depDescription = txtDepDescription.Text.Trim();

            try
            {
                conn.Open();

                string query = "INSERT INTO department(departmentName,description) VALUES(@name,@description)";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@name", depName);
                command.Parameters.AddWithValue("@description", depDescription);

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
        // hindi pa siya integrated mismo 
        // kasi meron pa ako tanong kung ano plan natin pag update
        // kung meron o wla na
        private void UpdatingDepartment()
        {
            string depName = txtDepName.Text.Trim();
            string depDescription = txtDepDescription.Text.Trim();

            try
            {
                conn.Open();

                string query = "UPDATE department SET departmentName = @name, description = @description";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@name", depName);
                command.Parameters.AddWithValue("@description", depDescription);

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
        // same din dito
        private void DeletingDepartment()
        {

            if (dataGridViewDepartments.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowCell = dataGridViewDepartments.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridViewDepartments.Rows[selectedRowCell];
            string depId = selectedRow.Cells["departmentId"].Value.ToString();

            try
            {
                conn.Open();

                string query = "DELETE FROM department WHERE departmentId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@id", depId);

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
