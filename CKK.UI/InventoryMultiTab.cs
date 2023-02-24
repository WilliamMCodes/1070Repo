using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKK.Logic.Models;
using CKK.DB.UOW;

namespace CKK.GUI.WinForms
{
    public partial class InventoryMultiTab : UserControl
    {
        public InventoryMultiTab()
        {
            InitializeComponent();
        }

        public event EventHandler logoutButtonClick;
        public event EventHandler searchButtonClick;
        public event EventHandler editButtonClick;
        public event EventHandler addItemButtonClick;
        public event EventHandler removeButtonClick;

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (logoutButtonClick != null)
                logoutButtonClick(this, e);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchButtonClick != null)
                searchButtonClick(this, e);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (editButtonClick != null)
                editButtonClick(this, e);
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (addItemButtonClick != null)
                addItemButtonClick(this, e);
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            if (removeButtonClick != null)
                removeButtonClick(this, e);
        }

        public async Task PopulateInventory(UnitOfWork exampleStore)
        {
            inventoryListBox1.Items.Clear();
            foreach (Product storeItem in await exampleStore.Products.GetAll())
            {
                if (storeItem != null)
                {
                    try
                    {
                        inventoryListBox1.Items.Add(storeItem.ToString());
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }   
            }
            Refresh();
        }

        public void PopulateInventory(List<Product> items)
        {
            inventoryListBox1.Items.Clear();
            foreach (Product storeItem in items)
            {
                if (storeItem != null)
                {
                    if (inventoryListBox1.Items.Add(storeItem.ToString()) == -1)
                    {
                        MessageBox.Show("Error populating item list.");
                    }
                }
            }
            Refresh();
        }
    }
}
