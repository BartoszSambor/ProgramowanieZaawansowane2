using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient.FirstPage
{
    public partial class MenuUser : Form
    {
        private string login;
        public MenuUser(string login)
        {
            this.login = login;
            InitializeComponent();
        }
        
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            new BookBrowsing(login, true, true).Show();
        }

        private void buttonMyBooks_Click(object sender, EventArgs e)
        {
            new Browsing.MyBooks(login).Show();
        }
        
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            new Browsing.History(login).Show();
        }

        private void buttonSubscriptions_Click(object sender, EventArgs e)
        {
            new Browsing.Subscritpions(login).Show();
        }
    }
}
