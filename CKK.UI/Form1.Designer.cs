
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
            this.loginTool1 = new CKK.GUI.WinForms.LoginTool();
            this.inventoryMultiTab1 = new CKK.GUI.WinForms.InventoryMultiTab();
            this.loginTool1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTool1
            // 
            this.loginTool1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loginTool1.Controls.Add(this.inventoryMultiTab1);
            this.loginTool1.Location = new System.Drawing.Point(0, 0);
            this.loginTool1.Name = "loginTool1";
            this.loginTool1.Size = new System.Drawing.Size(1296, 163);
            this.loginTool1.TabIndex = 0;
            this.loginTool1.loginButtonClick += new System.EventHandler(this.LoginTool_loginButtonClick);
            // 
            // inventoryMultiTab1
            // 
            this.inventoryMultiTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inventoryMultiTab1.Location = new System.Drawing.Point(0, 0);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 683);
            this.Controls.Add(this.loginTool1);
            this.Name = "Form1";
            this.Text = "CKK Inventory Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginTool1.ResumeLayout(false);
            this.loginTool1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LoginTool loginTool1;

        protected void LoginTool_loginButtonClick(object sender, System.EventArgs e)
        {
            this.inventoryMultiTab1.userIDLabel.Text = loginTool1.userTextBox.Text;
            this.inventoryMultiTab1.accessLevelLabel.Text = "Permission Level: Debug";
            this.loginTool1.Visible = false;
            this.loginTool1.Enabled = false;
            this.inventoryMultiTab1.Enabled = true;
            this.inventoryMultiTab1.Visible = true;
        }

        private InventoryMultiTab inventoryMultiTab1;

        protected void inventoryMultiTab1_LogoutClick(object sender, System.EventArgs e)
        {
            this.inventoryMultiTab1.Enabled = false;
            this.inventoryMultiTab1.Visible = false;
            this.loginTool1.Visible = true;
            this.loginTool1.Enabled = true;
            this.loginTool1.userTextBox.Clear();
            this.loginTool1.passwordTextBox.Clear();
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

        }

        protected void AddItem(Logic.Models.Store exampleStore)
        {
            new AddNewItemForm(exampleStore);
            inventoryMultiTab1.populateInventory(exampleStore);
        }
    }
}