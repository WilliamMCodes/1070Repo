﻿using System;
using System.Windows.Forms;
using CKK.Logic.Models;

namespace CKK.GUI.WinForms
{
    public partial class Form1 : Form
    {
        public Store Store { get; set; }
        public Form1(Logic.Models.Store store)
        {
            InitializeComponent();
            Store = store;
            inventoryMultiTab1.userIDLabel.Text = $"User ID: {Program.UserName}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        static public void RunInventory(Form1 form)
        {
            form.inventoryMultiTab1.PopulateInventory(form.Store);
        }

    }
}
