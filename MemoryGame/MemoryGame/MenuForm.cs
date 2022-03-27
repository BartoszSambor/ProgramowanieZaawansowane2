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

namespace MemoryGame
{
    public partial class MenuForm : Form
    {
        private StartingForm parent;
        private Settings settings;

        public MenuForm(StartingForm parent, string username)
        {
            this.parent = parent;
            settings = new Settings(username);
            InitializeComponent();
        }

        public void SetSettings(Settings settings)
        {
            this.settings = settings;
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(this, settings);
            settingsForm.Location = this.Location;
            settingsForm.StartPosition = FormStartPosition.Manual;
            settingsForm.ShowDialog();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("card count: " + settings.cardCount.ToString());
            var settingsForm = new Game(settings);
            settingsForm.Location = this.Location;
            settingsForm.StartPosition = FormStartPosition.Manual;
            settingsForm.FormClosing += delegate { parent.Show(); this.Show();};
            settingsForm.Show();
            parent.Hide();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ranking = new Ranking("stefan", 29);
            ranking.Show();
        }
    }
}
