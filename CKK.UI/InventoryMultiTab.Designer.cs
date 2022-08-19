
namespace CKK.GUI.WinForms
{
    partial class InventoryMultiTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryMultiTab));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.inventoryTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.accessLevelLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.inventoryPanel = new System.Windows.Forms.Panel();
            this.labelSearch = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.inventoryTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.inventoryTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1295, 599);
            this.tabControl1.TabIndex = 0;
            // 
            // inventoryTab
            // 
            this.inventoryTab.BackColor = System.Drawing.Color.White;
            this.inventoryTab.Controls.Add(this.removeItemButton);
            this.inventoryTab.Controls.Add(this.addItemButton);
            this.inventoryTab.Controls.Add(this.editButton);
            this.inventoryTab.Controls.Add(this.searchButton);
            this.inventoryTab.Controls.Add(this.searchTextBox);
            this.inventoryTab.Controls.Add(this.labelSearch);
            this.inventoryTab.Controls.Add(this.inventoryPanel);
            this.inventoryTab.Location = new System.Drawing.Point(4, 29);
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.inventoryTab.Size = new System.Drawing.Size(1287, 566);
            this.inventoryTab.TabIndex = 0;
            this.inventoryTab.Text = "Store Inventory";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1287, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "other tabs as needed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // userIDLabel
            // 
            this.userIDLabel.Location = new System.Drawing.Point(4, 4);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(274, 24);
            this.userIDLabel.TabIndex = 1;
            this.userIDLabel.Text = "User ID Label";
            this.userIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // accessLevelLabel
            // 
            this.accessLevelLabel.Location = new System.Drawing.Point(284, 4);
            this.accessLevelLabel.Name = "accessLevelLabel";
            this.accessLevelLabel.Size = new System.Drawing.Size(274, 24);
            this.accessLevelLabel.TabIndex = 2;
            this.accessLevelLabel.Text = "Permission Level:";
            this.accessLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Red;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logoutButton.Location = new System.Drawing.Point(1216, 4);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 25);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // inventoryPanel
            // 
            this.inventoryPanel.AutoScroll = true;
            this.inventoryPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.inventoryPanel.Location = new System.Drawing.Point(0, 56);
            this.inventoryPanel.Name = "inventoryPanel";
            this.inventoryPanel.Size = new System.Drawing.Size(1287, 511);
            this.inventoryPanel.TabIndex = 0;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(3, 14);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(73, 13);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Search By ID:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(3, 30);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(139, 20);
            this.searchTextBox.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Blue;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.Location = new System.Drawing.Point(148, 28);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.BlueViolet;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editButton.Location = new System.Drawing.Point(229, 28);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.BackColor = System.Drawing.Color.Gold;
            this.addItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemButton.Location = new System.Drawing.Point(311, 28);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(75, 23);
            this.addItemButton.TabIndex = 5;
            this.addItemButton.Text = "Add Item +";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // removeItemButton
            // 
            this.removeItemButton.BackColor = System.Drawing.Color.Orange;
            this.removeItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeItemButton.Location = new System.Drawing.Point(392, 28);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(75, 23);
            this.removeItemButton.TabIndex = 6;
            this.removeItemButton.Text = "Remove";
            this.removeItemButton.UseVisualStyleBackColor = false;
            this.removeItemButton.Click += new System.EventHandler(this.removeItemButton_Click);
            // 
            // InventoryMultiTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.accessLevelLabel);
            this.Controls.Add(this.userIDLabel);
            this.Controls.Add(this.tabControl1);
            this.Name = "InventoryMultiTab";
            this.Size = new System.Drawing.Size(1295, 682);
            this.tabControl1.ResumeLayout(false);
            this.inventoryTab.ResumeLayout(false);
            this.inventoryTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage inventoryTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Label accessLevelLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Panel inventoryPanel;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button removeItemButton;
    }
}
