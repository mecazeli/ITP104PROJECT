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
        public Login(Admin admin) : this()
        {
            _admin = admin;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

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

            string correctUsername = _admin.username;
            string correctPassword = _admin.password;


            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                this.Hide();
                Dashboard dashboard = new Dashboard(_admin);
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

    }

    public class Admin
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Admin()
        {}

        public Admin(string admName, int admAge, string admGender, string admUsername, string admPassword)
        {
            name = admName;
            age = admAge;
            gender = admGender;
            username = admUsername;
            password = admPassword;
        }
    }
}
