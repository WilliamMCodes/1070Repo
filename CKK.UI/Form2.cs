﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void loginTool1_loginButtonClick(object sender, EventArgs e)
        {
            Program.UserName = loginTool1.userTextBox.Text;
            Close();
        }
    }
}
