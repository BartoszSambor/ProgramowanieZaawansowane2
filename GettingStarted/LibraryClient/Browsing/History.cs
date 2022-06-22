using LibraryClient.ServiceReference1;
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

namespace LibraryClient.Browsing
{
    public partial class History : Form
    {
        private string login;
        CalculatorClient client = new CalculatorClient();
        public History(string login)
        {
            this.login = login;
            InitializeComponent();
            //dataGridView1.DataSource = new BindingSource(filteredBooks, null);
        }

        private void History_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("test", "Time");
            dataGridView1.Columns.Add("test2", "Time2");

            var borrowed = client.GetHistory(login).ToList<BorrowedHistory>();
            var books = borrowed.Select(x => x.Book).ToList<Book>();
            bookBindingSource1.DataSource = new BindingSource(books, null);
            Debug.WriteLine("ROW COUNT: " + dataGridView1.RowCount);

            for (int i = 0; i < books.Count; i++)
            {
                dataGridView1[8, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().BorrowTime?.ToShortDateString();
                dataGridView1[9, i].Value = borrowed.Where(x => x.BookId == books[i].Id)?.First().ReturnDeadline?.ToShortDateString();
            }
        }
    }
}
