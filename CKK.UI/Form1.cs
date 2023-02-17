using System;
using System.Windows.Forms;
using CKK.Logic.Models;
using CKK.DB.UOW;

namespace CKK.GUI.WinForms
{
    public partial class Form1 : Form
    {
        public UnitOfWork Store { get; set; }
        public Form1(UnitOfWork store)
        {
            InitializeComponent();
            Store = store;
            inventoryMultiTab1.userIDLabel.Text = $"User ID: {Program.UserName}";
            RunInventory(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        static public void RunInventory(Form1 form)
        {
            form.inventoryMultiTab1.PopulateInventory(form.Store);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                inventoryMultiTab1.PopulateInventory(Store.Products.GetAll(1));
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                inventoryMultiTab1.PopulateInventory(Store.GetProductsByQuantity());
            }
        }
    }
}
