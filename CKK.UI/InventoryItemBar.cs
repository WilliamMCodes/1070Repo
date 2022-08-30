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
    public partial class InventoryItemBar : UserControl
    {
        public InventoryItemBar(int id, string name, decimal price, int quantity)
        {
            itemIDLabel.Text = id.ToString();
            descriptionTextBox.Text = name;
            priceTextBox.Text = $"USD\r\n { price: C2}";
            numericUpDown1.Value = quantity;
            InitializeComponent();
        }

        public event EventHandler confirmButtonClick;

        private void button1_Click(object sender, EventArgs e)
        {
            if (confirmButtonClick != null)
                confirmButtonClick(this, e);
        }
    }
}
