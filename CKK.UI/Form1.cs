using System;
using System.Windows.Forms;
using CKK.Logic.Models;

namespace CKK.GUI.WinForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Store testStore = new Store();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
