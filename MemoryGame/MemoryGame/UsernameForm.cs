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
            if(validateUsername())
                parent.UsernameSelected(textBox1.Text);
            else
            {
                MessageBox.Show("Nie podano nicku", "Błąd");
            }
        }
        
        // returns true if user nick is correct
        private bool validateUsername()
        {
            return textBox1.Text.Length > 0;
        }
    }
}
