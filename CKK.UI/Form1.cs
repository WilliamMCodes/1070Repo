using System;
using System.Windows.Forms;
using CKK.Logic.Models;
using CKK.DB.UOW;
using System.Runtime.CompilerServices;

namespace CKK.GUI.WinForms
{
    public partial class Form1 : Form
    {
        public UnitOfWork Store { get; set; }
        public Form1(UnitOfWork store)
        {
            InitializeComponent();
            Store = store;
            inventoryMultiTab1.userIDLabel.Text = $"User ID: {store.GetCustomerName()}";
            Task.Run(() => RunInventory(this));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        static public async Task RunInventory(Form1 form)
        {
            await form.Invoke(async () => await form.inventoryMultiTab1.PopulateInventory(form.Store));
            form.Refresh();
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                inventoryMultiTab1.PopulateInventory(await Store.Products.GetAll(1));
            }
        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                inventoryMultiTab1.PopulateInventory(await Store.Products.GetAll(2));
            }
        }
    }
}
