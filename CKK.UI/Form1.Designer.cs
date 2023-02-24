using CKK.DB.UOW;
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.inventoryMultiTab1 = new CKK.GUI.WinForms.InventoryMultiTab();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(562, 162);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(108, 19);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Sort All by Price";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(676, 162);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(128, 19);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Sort All by Quantity";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // inventoryMultiTab1
            // 
            this.inventoryMultiTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inventoryMultiTab1.Location = new System.Drawing.Point(0, -1);
            this.inventoryMultiTab1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inventoryMultiTab1.Name = "inventoryMultiTab1";
            this.inventoryMultiTab1.Size = new System.Drawing.Size(1295, 682);
            this.inventoryMultiTab1.TabIndex = 1;
            this.inventoryMultiTab1.logoutButtonClick += new System.EventHandler(this.inventoryMultiTab1_LogoutClick);
            this.inventoryMultiTab1.searchButtonClick += new System.EventHandler(this.inventoryMultiTab1_SearchClick);
            this.inventoryMultiTab1.editButtonClick += new System.EventHandler(this.inventoryMultiTab1_EditClick);
            this.inventoryMultiTab1.addItemButtonClick += new System.EventHandler(this.inventoryMultiTab1_AddItemClick);
            this.inventoryMultiTab1.removeButtonClick += new System.EventHandler(this.inventoryMultiTab1_RemoveItemClick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1295, 680);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.inventoryMultiTab1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected void inventoryMultiTab1_LogoutClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        protected void inventoryMultiTab1_SearchClick(object sender, System.EventArgs e)
        {
            inventoryMultiTab1.PopulateInventory(Store.Products.GetByName(inventoryMultiTab1.searchTextBox.Text).Result);
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        protected void inventoryMultiTab1_EditClick(object sender, System.EventArgs e)
        {
            for (int x = inventoryMultiTab1.inventoryListBox1.CheckedItems.Count - 1; x >= 0; x--)
            {
                string testString1 = inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Substring(7, 20);
                EditItem(Store, testString1);
            }
        }

        protected void inventoryMultiTab1_AddItemClick(object sender, System.EventArgs e)
        {
            AddItem(Store);
        }

        protected void inventoryMultiTab1_RemoveItemClick(object sender, System.EventArgs e)
        {
            for(int x = inventoryMultiTab1.inventoryListBox1.CheckedItems.Count - 1; x >= 0; x--)
            {
                string testString1 = inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Substring(7, 20); //ProductId
                string testString2 = inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Substring(118, inventoryMultiTab1.inventoryListBox1.CheckedItems[x].ToString().Length - 118); //Quantity
                RemoveItem(testString1, testString2);
            }
        }

        protected void AddItem(UnitOfWork exampleStore)
        {
            AddNewItemForm additemForm = new AddNewItemForm(exampleStore, this);
            additemForm.Show();
        }

        protected void RemoveItem(string itemID, string itemQuantity)
        {
            Store.Products.Delete(int.Parse(itemID));
            inventoryMultiTab1.PopulateInventory(Store);
        }

        protected void EditItem(UnitOfWork store, string id)
        {
            EditItemsForm editItemsForm = new EditItemsForm(store, int.Parse(id), this);
            editItemsForm.Show();
        }

        private InventoryMultiTab inventoryMultiTab1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}