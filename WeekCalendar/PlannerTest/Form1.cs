using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
/*            string[] s = textBox1.Text.Split(' ');
            int x = int.Parse(s[0]);
            int y = int.Parse(s[1]);*/

           //weekPlanner1.SetPeriodValue(textBox2.Text, colorDialog1.Color, weekPlanner1);
            weekPlanner1.SetSelectedPeriodsValue(textBox2.Text, colorDialog1.Color);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button2.BackColor = colorDialog1.Color;
        }
    }
}
