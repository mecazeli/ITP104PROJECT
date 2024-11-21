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
        public Departments()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
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
    }
}
