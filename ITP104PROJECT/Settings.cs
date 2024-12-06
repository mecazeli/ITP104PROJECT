using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProjectName.My_Classes;


namespace ITP104PROJECT
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBackPath.Text))
                {
                    MessageBox.Show("Please select a backup path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string backupPath = txtBackPath.Text;
                string query = ("BACKUP DATABASE company TO DISK = '"+txtBackPath.Text+"'");
                MessageBox.Show("Backup Done Successfully!");

                // Assuming DB_General is correctly implemented
                DB_General obj = new DB_General();
                obj.general_query(query);

                MessageBox.Show("Database backup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBackPath.Text = saveFileDialog.FileName;
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {

        }
    }
}
