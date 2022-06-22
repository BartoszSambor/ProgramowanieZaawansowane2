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
    public partial class MenuLibrarian : Form
    {
        private string login;
        public MenuLibrarian(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void buttonBrowse_Click_1(object sender, EventArgs e)
        {
            new BookBrowsing(login, false, false).Show();

        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            new Browsing.HistoryAdmin().Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CreateUpdate.AddingBook().Show();
        }
    }
}
