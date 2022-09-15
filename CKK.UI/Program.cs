using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKK.GUI.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 loginForm = new Form2();
            Application.Run(loginForm);
            Application.Run(new Form1(new Persistance.Models.FileStore()));
        }

        static private string userName;

        static public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

    }
}
