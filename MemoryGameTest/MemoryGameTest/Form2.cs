﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameTest
{
    public partial class Form2 : Form
    {
        public Form2(GameSettings settings)
        {
            InitializeComponent();
            this.textBox1.Text = settings.boardSize.ToString();
            this.textBox2.Text = settings.timeToRemember.ToString();
            this.textBox3.Text = settings.timeToHide.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public GameSettings GetSettings()
        {
            return new GameSettings(
                int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
                int.Parse(textBox3.Text)
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
