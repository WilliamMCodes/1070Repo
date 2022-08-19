
namespace CKK.GUI.WinForms
{
    partial class InventoryItemBar
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
            this.checkBoxItemSelect = new System.Windows.Forms.CheckBox();
            this.itemIDLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxItemSelect
            // 
            this.checkBoxItemSelect.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxItemSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxItemSelect.Location = new System.Drawing.Point(3, 3);
            this.checkBoxItemSelect.Name = "checkBoxItemSelect";
            this.checkBoxItemSelect.Size = new System.Drawing.Size(25, 25);
            this.checkBoxItemSelect.TabIndex = 0;
            this.checkBoxItemSelect.UseVisualStyleBackColor = true;
            // 
            // itemIDLabel
            // 
            this.itemIDLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemIDLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.itemIDLabel.Location = new System.Drawing.Point(30, 0);
            this.itemIDLabel.Name = "itemIDLabel";
            this.itemIDLabel.Size = new System.Drawing.Size(118, 30);
            this.itemIDLabel.TabIndex = 1;
            this.itemIDLabel.Text = "#-#####-#####-#";
            this.itemIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.descriptionTextBox.Location = new System.Drawing.Point(148, 0);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionTextBox.MaximumSize = new System.Drawing.Size(395, 30);
            this.descriptionTextBox.MinimumSize = new System.Drawing.Size(395, 30);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(395, 30);
            this.descriptionTextBox.TabIndex = 2;
            this.descriptionTextBox.Text = "Name/Description of Item";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(548, 6);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.MaximumSize = new System.Drawing.Size(120, 0);
            this.numericUpDown1.MinimumSize = new System.Drawing.Size(90, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.priceTextBox.Location = new System.Drawing.Point(672, 0);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.priceTextBox.MaximumSize = new System.Drawing.Size(75, 30);
            this.priceTextBox.MinimumSize = new System.Drawing.Size(75, 30);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.ReadOnly = true;
            this.priceTextBox.Size = new System.Drawing.Size(75, 30);
            this.priceTextBox.TabIndex = 4;
            this.priceTextBox.Text = "USD:";
            this.priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.notesTextBox.Location = new System.Drawing.Point(747, 0);
            this.notesTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.notesTextBox.MaximumSize = new System.Drawing.Size(400, 30);
            this.notesTextBox.MinimumSize = new System.Drawing.Size(400, 30);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ReadOnly = true;
            this.notesTextBox.Size = new System.Drawing.Size(400, 30);
            this.notesTextBox.TabIndex = 5;
            this.notesTextBox.Text = "Notes:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1151, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InventoryItemBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.itemIDLabel);
            this.Controls.Add(this.checkBoxItemSelect);
            this.Name = "InventoryItemBar";
            this.Size = new System.Drawing.Size(1260, 30);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxItemSelect;
        private System.Windows.Forms.Label itemIDLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Button button1;
    }
}
