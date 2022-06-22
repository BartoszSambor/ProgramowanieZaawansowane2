using LibraryClient.ServiceReference1;
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
    public partial class Subscritpions : Form
    {
        private string login;
        private CalculatorClient client = new CalculatorClient();
        public Subscritpions(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void Subscritpions_Load(object sender, EventArgs e)
        {
            var types = client.GetSubscriptions(login);
            foreach(var type in types)
            {
                textBox1.AppendText(type + Environment.NewLine);
            }

            var notifications = client.GetNotifications(login);
            var books = notifications.Select(x => x.Book).ToList();
            dataGridView1.DataSource = new BindingSource(books, null);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var subscriptions = textBox1.Text.Split('\n');
            for(int i = 0; i < subscriptions.Length; i++) 
            { 
                if (char.IsWhiteSpace(subscriptions[i][subscriptions[i].Length-1]))
                {
                    subscriptions[i] = subscriptions[i].Remove(subscriptions[i].Length - 1, 1);
                }
            }
            client.SubscribeAndClear(login, subscriptions);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.ClearNotifications(login);
            dataGridView1.DataSource = new BindingSource(new List<Book>(), null);
        }
    }
}
