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
    public partial class Registration : Form
    {
        private bool adminPriv = false;
        public Registration(bool priv)
        {
            this.adminPriv = priv;
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateLoginPassword())
            {
                return;
            } 
        }

        private bool ValidateLoginPassword()
        {
            if (textBoxLogin.Text.Length <= 0)
            {
                MessageBox.Show("Login incorrect");
                return false;
            }
            else if (textBoxPassword1.Text.Length <= 0)
            {
                MessageBox.Show("Password incorrect");
                return false;

            }
            else if (!textBoxPassword1.Text.Length.Equals(textBoxPassword2.Text.Length))
            {
                MessageBox.Show("Passwords are not the same");
                return false;

            }
            else if (comboBoxType.Text == String.Empty)
            {
                MessageBox.Show("Select account type");
                return false;
            }
            else             
            {
                UserServerClient client = new UserServerClient();
                if(client.CreateUser(textBoxLogin.Text, textBoxPassword1.Text, comboBoxType.Text))
                {
                    MessageBox.Show("Account created");
                    return true;
                }
                else
                {
                    MessageBox.Show("Account with that login already exist");
                    return false;
                }
            }
            
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            //ValidateLoginPassword();
        }

        private void textBoxPassword1_TextChanged(object sender, EventArgs e)
        {
           //ValidateLoginPassword();
        }

        private void textBoxPassword2_TextChanged(object sender, EventArgs e)
        {
            //ValidateLoginPassword();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            if (!adminPriv)
            {
                comboBoxType.Items.Clear();
                comboBoxType.Items.Add("User");
            }
        }
    }
}
