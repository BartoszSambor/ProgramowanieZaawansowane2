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
    public partial class StartingForm : Form
    {
        UsernameForm usernameChild;
        MenuForm menuChild;
        public StartingForm()
        {
            InitializeComponent();
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {
            usernameChild = new UsernameForm(this);
            LoadChild(usernameChild);
        }

        public void UsernameSelected(string username)
        {
            menuChild = new MenuForm(this, username);
            usernameChild.Hide();
            LoadChild(menuChild);
        }

        // fill panel with borderless form provided
        private void LoadChild(Form child)
        {
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            content.Controls.Add(child);
            content.Tag = child;
            child.BringToFront();
            child.Show();
        }


    }
}
