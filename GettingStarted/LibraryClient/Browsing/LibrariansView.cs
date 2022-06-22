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

namespace LibraryClient.Browsing
{
    public partial class LibrariansView : Form
    {
        public LibrariansView()
        {
            InitializeComponent();
        }

        private void LibrariansView_Load(object sender, EventArgs e)
        {
            UserServerClient clientUsers = new UserServerClient();
            var libs = clientUsers.GetLibrarians();
            var sb = new StringBuilder();
            foreach(var lib in libs)
            {
                sb.AppendLine(lib.Login);
            }
            textBox1.Text = sb.ToString();
        }
    }
}
