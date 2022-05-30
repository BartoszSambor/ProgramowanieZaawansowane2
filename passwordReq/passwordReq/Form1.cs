using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordReq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.TextChanged += delegate { imageCheckBoxList1.UpdateCheckboxes(textBox2.Text); this.CheckIfValid(imageCheckBoxList1.IsPasswordValid()); };
        }

        private void CheckIfValid(bool isValid)
        {
            if (isValid)
            {
                label1.Text = "Password is valid";
            }
            else
            {
                label1.Text = "Password is not valid";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            imageCheckBoxList1.SpecialCharacters = textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageCheckBoxList1.MinLength = (int)numericUpDown1.Value;
        }
    }
}
