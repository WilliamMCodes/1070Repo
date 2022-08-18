
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.inventoryTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.accessLevelLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.inventoryTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 150);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1316, 570);
            this.tabControl1.TabIndex = 0;
            // 
            // inventoryTab
            // 
            this.inventoryTab.BackColor = System.Drawing.Color.White;
            this.inventoryTab.Location = new System.Drawing.Point(4, 29);
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.inventoryTab.Size = new System.Drawing.Size(1308, 537);
            this.inventoryTab.TabIndex = 0;
            this.inventoryTab.Text = "Store Inventory";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1308, 537);
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
            this.logoutButton.Location = new System.Drawing.Point(1237, 5);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 25);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = false;
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
            this.Size = new System.Drawing.Size(1316, 723);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage inventoryTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Label accessLevelLabel;
        private System.Windows.Forms.Button logoutButton;
    }
}
