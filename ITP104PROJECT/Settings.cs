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
using System.Diagnostics;

namespace ITP104PROJECT
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void BackupDatabase(string backupFilePath)
        {
            try
            {
                string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";

                string command = $@"""{mysqldumpPath}"" --user=root --host=localhost company --result-
                file=""{backupFilePath}"" --no-tablespaces --skip-column-statistics";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",

                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine(command);
                        }
                    }
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error during backup: {error}", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Backup completed successfully!\nOutput: {output}", "Backup",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void RestoreDatabase(string backupFilePath)
        {
            try
            {
                string command = $@"mysql --user=root --password= --host=localhost company <
                ""{backupFilePath}""";
            
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine(command);
                        }
                    }
                    process.WaitForExit();
                }
                MessageBox.Show("Database restored successfully!", "Restore", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during restore: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        
        //private void btnBackup_Click(object sender, EventArgs e)
        //{
            
            


            //try
            //{
            //    if (string.IsNullOrEmpty(txtBackPath.Text))
            //    {
            //        MessageBox.Show("Please select a backup path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    string backupPath = txtBackPath.Text;
            //    string query = (" '"+txtBackPath.Text+"'");
            //    MessageBox.Show("Backup Done Successfully!");

            //    // Assuming DB_General is correctly implemented
            //    DB_General obj = new DB_General();
            //    obj.general_query(query);

            //    MessageBox.Show("Database backup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        //}
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL Files (.sql)|.sql";
                sfd.Title = "Save Database Backup";
                sfd.FileName = "sales_inventory_backup.sql";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = sfd.FileName;
                    MessageBox.Show(backupFilePath);
                    BackupDatabase(backupFilePath);
                }
            }
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "SQL Files (.sql)|.sql";
                ofd.Title = "Select Database Backup";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = ofd.FileName;
                    RestoreDatabase(txtBackPath.Text);
                }
            }
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

        //private void btnRestore_Click(object sender, EventArgs e)
        //{

        //}

        private void btnBrowse2_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
        //    txtNewUsername.Visible = true; // Show the textbox for new username
        //    btnConfirmNewUsername.Visible = true; // Show the confirm button (you can create it)
        //}

        //private void btnConfirmNewUsername_Click(object sender, EventArgs e)
        //{
        //    string newUsername = txtNewUsername.Text;

        //    if (!string.IsNullOrEmpty(newUsername))
        //    {
        //        // Update the username (store it in a variable, file, or database as needed)
        //        string updatedUsername = newUsername;
        //        MessageBox.Show("Username successfully updated.");

        //        // Optional: Hide the textbox and button after updating
        //        txtNewUsername.Visible = false;
        //        btnConfirmNewUsername.Visible = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid username.");
        //    }
        }

        
    }
}
