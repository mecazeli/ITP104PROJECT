using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITP104PROJECT
{
    public partial class Login : Form
    {

        public string password = "admin123";
        public string username = "Jessa Cariñaga";

        public Login()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nameInput = textBox1.Text;
            string passwordInput = textBox2.Text;

            if (nameInput == username && passwordInput == password)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();

            } else
            {
                MessageBox.Show("Invalid Input Please Try Again");
                textBox1.Clear();
                textBox2.Clear();
                
            }
        }
    }
}
