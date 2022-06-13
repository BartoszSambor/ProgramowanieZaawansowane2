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

namespace LibraryClient.CreateUpdate
{
    public partial class UpdateBooks : Form
    {
        CalculatorClient client = new CalculatorClient();
        List<Book> books;
        public UpdateBooks()
        {
            InitializeComponent();
        }

        private void UpdateBooks_Load(object sender, EventArgs e)
        {
            books = client.GetBooks().ToList<Book>();
            bookBindingSource.DataSource = new BindingSource(books, null);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Row 0:");
            Debug.WriteLine(books[0].Title);
            Book[] updated = new Book[1];
            updated[0] = books[0];
            client.UpdateBook(updated);
        }
    }
}
