using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        private MenuForm parent;
        public SettingsForm(MenuForm parent, Settings settings)
        {
            this.settings = settings;
            this.parent = parent;
            InitializeComponent();
            trackBar1.Value = settings.cardCount / 4;
            trackBar2.Value = settings.timeToRemember;
            trackBar3.Value = (int)(settings.hideTime*10);
            UpdateLabels();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var sett = new Settings(
                settings.nick,
                trackBar1.Value * 4,
                trackBar2.Value,
                trackBar3.Value / 10f
            );
            parent.SetSettings(sett);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void UpdateLabels()
        {
            label4.Text = (trackBar1.Value * 4).ToString();
            label5.Text = trackBar2.Value.ToString() + " s";
            label6.Text = (trackBar3.Value * 100).ToString() + " ms";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateLabels();
        }
    }
}
