﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient.FirstPage
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new LibraryClient.Login.Registration(true).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new LibraryClient.Browsing.LibrariansView().Show();
        }
    }
}