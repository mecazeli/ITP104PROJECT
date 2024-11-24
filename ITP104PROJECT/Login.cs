using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITP104PROJECT
{
    public partial class Login : Form
    {

        public static Admin admin;

        public Login()
        {
            InitializeComponent();
            admin = new Admin("Liezel T. Paciente", 30, "Female", "admin101", "password123");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(username.Length < 6  || !ContainsLetterAndNumbers(username))
            {
                MessageBox.Show("Username must be at least 6 characters long and contain both letters and numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(password.Length < 6 || !ContainsLetterAndNumbers(password))
            {
                MessageBox.Show("Username must be at least 6 characters long and contain both letters and numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(username == admin.username && password == admin.password)
            {
                MessageBox.Show("Login Successful!", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

                Dashboard dashboard = new Dashboard(admin);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ContainsLetterAndNumbers(string input)
        {
            bool hasLetter = false;
            bool hasNumber = false;

            foreach (char c in input)
            {
                if (char.IsLetter(c)) hasLetter = true;
                if (char.IsDigit(c)) hasNumber = true;

                if (hasLetter && hasNumber) return true;
            }

            return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Admin
    {
        public string name;
        public int age;
        public string gender;
        public string username;
        public string password;

        public Admin(string name, int age, string gender, string username, string password)
        {
            this.name = name;
            this.gender = gender;
            this.username = username;
            this.password = password;
        }
    }
}
