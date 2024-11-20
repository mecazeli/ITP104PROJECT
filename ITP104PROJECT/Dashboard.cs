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
    public partial class Dashboard : Form
    {
        public Admin admin;
        public Dashboard(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

       private void Dashboard_Load(object sender, EventArgs e)
        {
            lblName.Text = admin.name;
        }
    }
}
