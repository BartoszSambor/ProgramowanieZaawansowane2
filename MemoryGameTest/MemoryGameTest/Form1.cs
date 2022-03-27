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

namespace MemoryGameTest
{
    public partial class Form1 : Form
    {
        string userName;
        GameSettings settings = null;

        public Form1()
        {
            InitializeComponent();
            userControl11.addOnButtonSettingsClicked(delegate { Debug.WriteLine("setting"); this.ShowSettingForm();});
            userControl11.addOnButtonStartClicked(delegate { Debug.WriteLine("start"); this.ShowGameForm();});
        }

        private void userControl21_Load(object sender, EventArgs e)
        {
            
        }

        private void userControl21_VisibleChanged(object sender, EventArgs e)
        {
            if (!userControl21.Visible)
            {
                userName = userControl21.GetUserName();
                Debug.WriteLine("User name selected: " + userName);
            }
        }

        void ShowSettingForm()
        {
            GameSettings arg = settings == null ? new GameSettings() : settings;
            var frm = new Form2(arg);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { settings = frm.GetSettings();  this.Show(); this.ShowSettingTMP(); };
            frm.Show();
            this.Hide();
        }

        void ShowGameForm()
        {
            if(settings == null)
            {
                settings = new GameSettings();
            }
            var frm = new Form3(settings.boardSize);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); Debug.WriteLine("Game closed"); };
            frm.Show();
            this.Hide();
        }




        void ShowSettingTMP()
        {
            Debug.WriteLine(settings.boardSize);
            Debug.WriteLine(settings.timeToHide);
            Debug.WriteLine(settings.timeToRemember);
        }


        /*        private void button1_Click(object sender, EventArgs e)
                {
                    var frm = new Form2();
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.FormClosing += delegate { this.Show(); };
                    frm.Show();
                    this.Hide();
                }*/




    }
}
