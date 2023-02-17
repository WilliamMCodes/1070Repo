using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKK.DB.Repository;
using CKK.DB.UOW;
using CKK.Logic.Models;

namespace CKK.GUI.WinForms
{
    public partial class EditItemsForm : Form
    {
        private UnitOfWork Store { get; set; }
        private int ItemId { get; set; }
        private Form1 TargetForm { get; set; }
        private Product StoreItem { get; set; }
        public EditItemsForm(UnitOfWork store, int itemId, Form1 targetForm)
        {
            InitializeComponent();
            Store = store;
            ItemId = itemId;
            TargetForm = targetForm;
            StoreItem = Store.Products.GetbyId(ItemId);
            textBox1.Text = StoreItem.Id.ToString();
            textBox2.Text = StoreItem.Name;
            textBox3.Text = StoreItem.Price.ToString();
            quantityUpDown1.Value = StoreItem.Quantity;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreItem.Id = int.Parse(textBox1.Text);
            StoreItem.Name = textBox2.Text;
            StoreItem.Price = decimal.Parse(textBox3.Text);
            if(quantityUpDown1.Value >= 0)
            {
                StoreItem.Quantity = (int)quantityUpDown1.Value;
            }
            else
            {
                StoreItem.Quantity = 0;
            }
            Store.Products.Update(StoreItem);
            Form1.RunInventory(TargetForm);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
