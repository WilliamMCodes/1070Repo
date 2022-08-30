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
        public AddNewItemForm(Logic.Models.Store store)
        {
            Store = store;
            InitializeComponent();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            Store.AddStoreItem(new Logic.Models.Product(int.Parse(textBoxID.Text), 
                textBoxName.Text, decimal.Parse(textBoxPrice.Text)));
            Close();
        }
    }
}
