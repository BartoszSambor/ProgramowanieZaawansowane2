using LibraryClient.ServiceReference1;
using LibraryClient.ServiceReference2;
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


namespace LibraryClient
{
    public partial class Form1 : Form
    {
        
        CalculatorClient client = new CalculatorClient();
        UserServerClient clinetUsers = new UserServerClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Step 1: Create an instance of the WCF proxy.
            /*
                        Book book = new Book()
                        {
                            Title = "GOT",
                            Author = "Geogre Martin",
                            BookPrice = Decimal.Parse("9,99"),
                            BookType = "Fantasy",
                            BoughtCurrency = "PLN",
                            PagesCount = 1999              
                        };
                        client.InsertBook(book);
                        client.Close();*/

            //dataGridView1.Rows
            bookBindingSource.DataSource = client.GetBooks();
            var tmp = clinetUsers.GetLibrarians();

/*            comboBox1.Items.Clear();
            comboBox1.Items.Add("ala ma kota");
            comboBox1.Items.Add("tomek");
            comboBox1.Items.Add("bartek");
            comboBox1.Items.Add("ala ma świnkę");
            comboBox1.Items.Add("ala ma psa");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var books = client.GetBooks();
            foreach(var book in books)
            {
                textBox1.AppendText(book.Title + " " + book.Author);
            }
        }

        private void bookBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = client.GetBooks();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.InsertBook(
                new Book()
                {
                    Title = "GOT2",
                    Author = "Geogre Martin2",
                    Price = Decimal.Parse("9,99"),
                    Type = "Fantasy",
                    Currency = "PLN",
                    Pages = 1999
                });
            client.InsertBook(
    new Book()
    {
        Title = "GOT3",
        Author = "Geogre Martin3",
        Price = Decimal.Parse("9,99"),
        Type = "Fantasy",
        Currency = "PLN",
        Pages = 1999
    });
            client.InsertBook(
    new Book()
    {
        Title = "GOT2",
        Author = "Geogre Martin2",
        Price = Decimal.Parse("99,99"),
        Type = "Fantasy",
        Currency = "DE",
        Pages = 1999
    });
            client.InsertBook(
    new Book()
    {
        Title = "AOT",
        Author = "Seba",
        Price = Decimal.Parse("19,99"),
        Type = "History",
        Currency = "PLN",
        Pages = 1999
    });
        }

        private void bookBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new BookBrowsing("test user", true).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new LibraryClient.CreateUpdate.AddingBook().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new BookBrowsing("test user", false, true).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new LibraryClient.Login.Registration(false).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var users = clinetUsers.GetUsers();
            textBox2.Text = String.Empty;
            foreach (var user in users)
            {
                textBox2.AppendText(user.Login + " " + user.Password + Environment.NewLine);
            }
            var librarians = clinetUsers.GetLibrarians();
            foreach (var librarian in librarians)
            {
                textBox2.AppendText(librarian.Login + " " + librarian.Password + Environment.NewLine);
            }
            var admins = clinetUsers.GetAdmins();
            foreach (var admin in admins)
            {
                textBox2.AppendText(admin.Login + " " + admin.Password + Environment.NewLine);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Login.Login().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var borrowed = client.GetBorrowedBooksAll();
            textBox3.Text = String.Empty;
            Debug.WriteLine("Bowwored all count: " + borrowed.Count());
            foreach (var book in borrowed)
            {
                textBox3.AppendText(book.Book.Title + " " + book.Book.Author + " " + book.User + Environment.NewLine);
            }
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            new Browsing.MyBooks(textBox4.Text).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //dataGridView2.DataSource = client.GetBorrowedBooksWithTime(textBox4.Text);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            new Login.Login().Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new Browsing.History(textBox4.Text).Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Browsing.HistoryAdmin().Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            clinetUsers.CreateUser("admin", "admin", "Admin");
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Logic.ExchangeOperations.LoadRates();
            var c = Logic.ExchangeOperations.GetNames();
            for(int i = 0; i < c.Length; i++)
            {
                textBox5.AppendText(c[i] + " " + Logic.ExchangeOperations.ExchangeRateToEuro[c[i]] + Environment.NewLine);
            }

           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            var notfs = client.GetNotificationsAll();
            for (int i = 0; i < notfs.Length; i++)
            {
                textBox6.AppendText(notfs[i].User + " " + notfs[i].Time + " " + notfs[i].Book.Title + Environment.NewLine);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            var notfs = client.GetSubscriptionsAll();
            for (int i = 0; i < notfs.Length; i++)
            {
                textBox7.AppendText(notfs[i].User + " " + notfs[i].Type + Environment.NewLine);
            }
        }
    }
}
