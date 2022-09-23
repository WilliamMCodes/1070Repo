using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKK.GUI.WinForms
{
    public partial class EditItemsForm : Form
    {
        private Persistance.Models.FileStore Store { get; set; }
        private string ItemId { get; set; }
        private Form1 TargetForm { get; set; }
        private Logic.Models.StoreItem StoreItem { get; set; }
        public EditItemsForm(Persistance.Models.FileStore store, string itemId, Form1 targetForm)
        {
            InitializeComponent();
            Store = store;
            ItemId = itemId;
            TargetForm = targetForm;
            StoreItem = Store.FindStoreItemById(int.Parse(ItemId));
            textBox1.Text = StoreItem.Product.Id.ToString();
            textBox2.Text = StoreItem.Product.Name;
            textBox3.Text = StoreItem.Product.Price.ToString();
            quantityUpDown1.Value = StoreItem.Quantity;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreItem.Product.Id = int.Parse(textBox1.Text);
            StoreItem.Product.Name = textBox2.Text;
            StoreItem.Product.Price = decimal.Parse(textBox3.Text);
            if(StoreItem.Quantity < quantityUpDown1.Value)
            {
                Store.AddStoreItem(StoreItem.Product, (int)quantityUpDown1.Value - StoreItem.Quantity);
            }
            else if(StoreItem.Quantity > quantityUpDown1.Value)
            {
                Store.RemoveStoreItem(StoreItem.Product.Id, StoreItem.Quantity - (int)quantityUpDown1.Value);
            }
            TargetForm.Store.Save();
            Form1.RunInventory(TargetForm);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
