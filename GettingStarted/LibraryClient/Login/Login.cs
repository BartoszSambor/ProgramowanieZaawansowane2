using LibraryClient.ServiceReference2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (new UserServerClient().Login(textBoxLogin.Text, textBoxPassword.Text, comboBoxType.Text))
            {
                if(comboBoxType.Text == "Librarian")
                {
                    new FirstPage.MenuLibrarian(textBoxLogin.Text).Show();

                }
                else if(comboBoxType.Text == "Admin")
                {
                    new FirstPage.MenuAdmin().Show();
                } else
                {
                    new FirstPage.MenuUser(textBoxLogin.Text).Show();
                }
            }
            else
            {
                MessageBox.Show("Error");
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BookBrowsing(textBoxLogin.Text, true, false).Show();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            new LibraryClient.Login.Registration(false).Show();
        }
    }
}
