using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class UsernameForm : Form
    {
        StartingForm parent = null;
        public UsernameForm(StartingForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.UsernameSelected(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
