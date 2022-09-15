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
        public int ID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public InventoryItemBar(int id, string name, decimal price, int quantity)
        {
            ID = id;
            ItemName = name;
            Price = price;
            Quantity = quantity;
        }

        public event EventHandler confirmButtonClick;

        private void button1_Click(object sender, EventArgs e)
        {
            if (confirmButtonClick != null)
                confirmButtonClick(this, e);
        }

        private void InventoryItemBar_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            itemIDLabel.Text = ID.ToString();
            descriptionTextBox.Text = ItemName;
            priceTextBox.Text = $"USD\r\n { Price: C2}";
            numericUpDown1.Value = Quantity;
        }
    }
}
