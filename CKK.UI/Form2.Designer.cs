
namespace CKK.GUI.WinForms
{
    partial class Form2
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
            this.SuspendLayout();
            // 
            // loginTool1
            // 
            this.loginTool1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loginTool1.Location = new System.Drawing.Point(1, 0);
            this.loginTool1.Name = "loginTool1";
            this.loginTool1.Size = new System.Drawing.Size(330, 163);
            this.loginTool1.TabIndex = 0;
            this.loginTool1.loginButtonClick += new System.EventHandler(this.loginTool1_loginButtonClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 163);
            this.Controls.Add(this.loginTool1);
            this.Name = "Form2";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginTool loginTool1;
    }
}