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


namespace LibraryClient
{
    public partial class Form1 : Form
    {

        CalculatorClient client = new CalculatorClient();
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
            new BookBrowsing(true).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new LibraryClient.CreateUpdate.AddingBook().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new BookBrowsing(false).Show();
        }
    }
}
