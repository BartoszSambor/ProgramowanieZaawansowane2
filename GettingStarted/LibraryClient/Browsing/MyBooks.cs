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
    
    
    public partial class MyBooks : Form
    {
        private void Copy(Book target, Book book)
        {
            target.Author = book.Author;
            target.Title = book.Title;
            target.Price = book.Price;
            target.Currency = book.Currency;
            target.Type = book.Type;
            target.Pages = book.Pages;
        }

        CalculatorClient client = new CalculatorClient();
        List<Book> books;
       // List<BookWithTime> books2 = new List<BookWithTime>();
        private string login;
        public MyBooks(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void MyBooks_Load(object sender, EventArgs e)
        {
            /* dataGridView1.Columns.Add("test", "Header");
             books = client.GetBorrowedBooks(login).ToList<Book>();
             //
             var borrowed = client.GetBorrowedBooksWithTime(login).ToList<BorrowedElem>();
             foreach(Book b in books)
             {
                 var bookWithTime = new BookWithTime();
                 Copy(bookWithTime, b);
                 bookWithTime.ReturnDeadline = borrowed.Where(x => x.BookId == b.Id).First().ReturnDeadline;
             }

             bookBindingSource.DataSource = new BindingSource(books, null);*/
            
            dataGridView1.Columns.Add("test", "Time");
            var borrowed = client.GetBorrowedBooksWithTime(login).ToList<BorrowedElem>();
            books = borrowed.Select(x => x.Book).ToList<Book>();
            bookBindingSource.DataSource = new BindingSource(books, null);

            for (int i = 0; i < books.Count; i++)
            {
                dataGridView1[8, i].Value = borrowed.Where(x => x.BookId == books[i].Id).First().ReturnDeadline?.ToShortDateString();
            }
        }

        private void buttonGiveBack_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("Title: ");
                var selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
                if(selectedBook == null)
                {
                    return;
                }
                Debug.WriteLine("Book to return id: " + selectedBook.Id);
                sb.Append(selectedBook.Title);
                if (client.ReturnBook(login, selectedBook))
                {
                    selectedBook.Borrowed = false;
                    MessageBox.Show(sb.ToString(), "Returned");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                books.Remove(selectedBook);
                bookBindingSource.DataSource = new BindingSource(books, null);
                var borrowed = client.GetBorrowedBooksWithTime(login).ToList<BorrowedElem>();
                for (int i = 0; i < books.Count; i++)
                {
                    dataGridView1[8, i].Value = borrowed.Where(x => x.BookId == books[i].Id).First().ReturnDeadline?.ToShortDateString();
                }
            }
        }
    }
}
