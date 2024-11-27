using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITP104PROJECT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Admin admin = new Admin("Liezel T. Paciente", 30, "Female", "admin101", "password123");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Project());
=======
            Application.Run(new Dashboard(admin));
>>>>>>> b9cd67bbdf727a4f0bb9b5b5a42dba7cbac7a7e0
        }
    }
}
