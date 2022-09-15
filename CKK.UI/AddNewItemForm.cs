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
    public partial class AddNewItemForm : Form
    {
        public Logic.Models.Store Store { get; set; }
        public Form1 TargetForm { get; set; }
        public AddNewItemForm(Logic.Models.Store store, Form1 passedForm)
        {
            Store = store;
            TargetForm = passedForm;
            InitializeComponent();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            Store.AddStoreItem(new Logic.Models.Product(Convert.ToInt32(textBoxID.Text), 
                textBoxName.Text, decimal.Parse(textBoxPrice.Text)));
            Form1.RunInventory(TargetForm);
            /*foreach(Control control in TargetForm.Controls)
            {
                control.Visible = true;
                control.Enabled = true;
                MakeControlsVisible(control);
                
            }*/
            Close();
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
