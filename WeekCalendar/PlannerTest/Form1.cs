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

namespace PlannerTest
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            weekPlanner1.ShowMsgBox = checkBox1.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int minutes;
            if(textBox1.Text == String.Empty)
            {
                return;
            }
            if (!int.TryParse(textBox1.Text, out minutes))
            {
                textBox1.Text = "15";
                MessageBox.Show("Please enter a valid number of minutes");
            } else
            {
                weekPlanner1.RemindBefore = uint.Parse(textBox1.Text);
            }
        }

        private void weekPlanner1_EventReminder(object sender, EventArgs e)
        {
            label4.Text = "Last time event wall called: " + DateTime.Now.ToString();
        }
    }
}
