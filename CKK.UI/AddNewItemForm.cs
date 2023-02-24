using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKK.DB.UOW;
using CKK.Logic.Models;

namespace CKK.GUI.WinForms
{
    public partial class AddNewItemForm : Form
    {
        public UnitOfWork Store { get; set; }
        public Form1 TargetForm { get; set; }
        public AddNewItemForm(UnitOfWork store, Form1 passedForm)
        {
            Store = store;
            TargetForm = passedForm;
            InitializeComponent();
        }

        private async void buttonAddItem_Click(object sender, EventArgs e)
        {
            if(
                await Store.Products.Add(new Product
                {
                    Name = textBoxName.Text,
                    Price = decimal.Parse(textBoxPrice.Text),
                    Quantity = 1
                }) == 1
              )
            {
                await Form1.RunInventory(TargetForm);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add new item." + Environment.NewLine +
                    "Please ensure all fields were entered correctly  " + Environment.NewLine + 
                    "and that the item isn't a duplicate.", "Add New Item Failed.", 0);
            }
            
            /*foreach(Control control in TargetForm.Controls)
            {
                control.Visible = true;
                control.Enabled = true;
                MakeControlsVisible(control);
                
            }*/
        }

        private void MakeControlsVisible(Control control)
        {
            if(control.Controls.Count >= 1)
            {
                foreach(Control ctrl in control.Controls)
                {
                    ctrl.Visible = true;
                    ctrl.Enabled = true;
                    MakeControlsVisible(ctrl);
                }
            }
            return;
        }
    }
}
