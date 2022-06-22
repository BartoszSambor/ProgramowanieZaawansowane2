using LibraryClient.ServiceReference1;
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
    public partial class HistoryAdmin : Form
    {
        CalculatorClient client = new CalculatorClient();
        UserServerClient clientUsers = new UserServerClient();

        public HistoryAdmin()
        {
            InitializeComponent();
        }

        private void HistoryAdmin_Load(object sender, EventArgs e)
        {
            comboBoxUsers.Items.Clear();
            comboBoxUsers.Items.AddRange(clientUsers.GetUsers().Select(x => x.Login).ToArray());

            dataGridView1.Columns.Add("test", "Time");
            dataGridView1.Columns.Add("test2", "Time2");

            var borrowed = client.GetHistory(comboBoxUsers.Text).ToList<BorrowedHistory>();
            var books = borrowed.Select(x => x.Book).ToList<Book>();
            bookBindingSource.DataSource = new BindingSource(books, null);
            for (int i = 0; i < books.Count; i++)
            {
                dataGridView1[8, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().BorrowTime?.ToShortDateString();
                dataGridView1[9, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().ReturnDeadline?.ToShortDateString();
            }

            /*            dataGridView1.Columns.Add("test", "Time");
                        dataGridView1.Columns.Add("test2", "Time2");

                        var borrowed = client.GetHistory(login).ToList<BorrowedHistory>();
                        var books = borrowed.Select(x => x.Book).ToList<Book>();
                        bookBindingSource.DataSource = new BindingSource(books, null);

                        for (int i = 0; i < books.Count; i++)
                        {
                            dataGridView1[8, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().BorrowTime?.ToShortDateString();
                            dataGridView1[9, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().ReturnDeadline?.ToShortDateString();
                        }*/
        }

        private void comboBoxUsers_TextChanged(object sender, EventArgs e)
        {
            var borrowed = client.GetHistory(comboBoxUsers.Text).ToList<BorrowedHistory>();
            var books = borrowed.Select(x => x.Book).ToList<Book>();
            bookBindingSource.DataSource = new BindingSource(books, null);
            for (int i = 0; i < books.Count; i++)
            {
                dataGridView1[8, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().BorrowTime?.ToShortDateString();
                dataGridView1[9, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().ReturnDeadline?.ToShortDateString();
            }
        }
    }
}
