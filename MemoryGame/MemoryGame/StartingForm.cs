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
        string username;
        public StartingForm()
        {
            InitializeComponent();
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {
            var child = new UsernameForm(this);
            usernameChild = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            content.Controls.Add(child);
            content.Tag = child;
            child.BringToFront();
            child.Show();
        }

        public void UsernameSelected(string username)
        {
            this.username = username;
            var child = new MenuForm(this, username);
            menuChild = child;
            usernameChild.Hide();
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
