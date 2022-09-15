
namespace CKK.GUI.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inventoryMultiTab1 = new CKK.GUI.WinForms.InventoryMultiTab();
            this.SuspendLayout();
            // 
            // inventoryMultiTab1
            // 
            this.inventoryMultiTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inventoryMultiTab1.Location = new System.Drawing.Point(0, -1);
            this.inventoryMultiTab1.Name = "inventoryMultiTab1";
            this.inventoryMultiTab1.Size = new System.Drawing.Size(1295, 682);
            this.inventoryMultiTab1.TabIndex = 1;
            this.inventoryMultiTab1.removeButtonClick += new System.EventHandler(inventoryMultiTab1_RemoveItemClick);
            this.inventoryMultiTab1.addItemButtonClick += new System.EventHandler(inventoryMultiTab1_AddItemClick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1295, 680);
            this.Controls.Add(this.inventoryMultiTab1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        protected void inventoryMultiTab1_LogoutClick(object sender, System.EventArgs e)
        {
            Close();
        }

        protected void inventoryMultiTab1_SearchClick(object sender, System.EventArgs e)
        {

        }

        protected void inventoryMultiTab1_EditClick(object sender, System.EventArgs e)
        {

        }

        protected void inventoryMultiTab1_AddItemClick(object sender, System.EventArgs e)
        {
            AddItem(Store);
        }

        protected void inventoryMultiTab1_RemoveItemClick(object sender, System.EventArgs e)
        {
            for(int x = inventoryMultiTab1.inventoryListBox1.CheckedItems.Count - 1; x >= 0; x--)
            {
                string testString1 = inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Substring(7, 20);
                string testString2 = inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Substring(118, inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Length - 118);
                RemoveItem(testString1, testString2);
            }
        }

        protected void AddItem(Logic.Models.Store exampleStore)
        {
            AddNewItemForm additemForm = new AddNewItemForm(exampleStore, this);
            additemForm.Show();
        }

        protected void RemoveItem(string itemID, string itemQuantity)
        {
            Store.RemoveStoreItem(int.Parse(itemID),int.Parse(itemQuantity));
            inventoryMultiTab1.PopulateInventory(Store);
        }

        private InventoryMultiTab inventoryMultiTab1;
    }
}