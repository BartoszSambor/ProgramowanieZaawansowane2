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
    public partial class BookBrowsing : Form
    {
        CalculatorClient client = new CalculatorClient();
        UserServerClient clinetUsers = new UserServerClient();
        private string login;
        List<Book> books;
        List<Book> filteredBooks;
        public BookBrowsing(string login, bool readOnly = true, bool canBorrow = false)
        {
            this.login = login;
            InitializeComponent();
            dataGridView1.ReadOnly = readOnly;
            if (readOnly)
            {
                buttonSave.Visible = false;
                buttonRemove.Visible = false;
            }
            if (!canBorrow)
            {
                buttonBorrow.Visible = false;
            }
        }

        private void BookBrowsing_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("test2", "Euro price");
            books = client.GetBooks().ToList<Book>();
            filteredBooks = books;
            bookBindingSource.DataSource = new BindingSource(filteredBooks, null);
            FillComboboxes();
           
            for (int i = 0; i < books.Count; i++)
            {
                dataGridView1[8, i].Value = ToEUR(books[i].Price, books[i].Currency);
            }

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            comboBoxAuthorFilter.Text = String.Empty;
            comboBoxCurrencyFilter.Text = String.Empty;
            comboBoxTitleFilter.Text = String.Empty;
            comboBoxTypeFilter.Text = String.Empty;
            checkBoxAuthor.Checked = false;
            checkBoxCurrency.Checked = false;
            checkBoxTitle.Checked = false;
            checkBoxType.Checked = false;
            filteredBooks = books;
            FillComboboxes();
            Filter();
        }

        private void Filter()
        {
            filteredBooks = books;
            if (!checkBoxAuthor.Checked)
            {
                if (comboBoxAuthorFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Author == comboBoxAuthorFilter.Text).ToList();
            }
            else
            {
                if (comboBoxAuthorFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Author == comboBoxAuthorFilter.Text || x.Author is null).ToList();
            }

            if (!checkBoxCurrency.Checked)
            {
                if (comboBoxCurrencyFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Currency == comboBoxCurrencyFilter.Text).ToList();
            }
            else
            {
                if (comboBoxCurrencyFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Currency == comboBoxCurrencyFilter.Text || x.Currency is null).ToList();
            }

            if (!checkBoxTitle.Checked)
            {
                if (comboBoxTitleFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Title == comboBoxTitleFilter.Text).ToList();
            }
            else
            {
                if (comboBoxTitleFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Title == comboBoxTitleFilter.Text || x.Title is null).ToList();
            }

            if (!checkBoxType.Checked)
            {
                if (comboBoxTypeFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Type == comboBoxTypeFilter.Text).ToList();
            } else
            {
                if (comboBoxTypeFilter.Text != String.Empty)
                    filteredBooks = filteredBooks.Where(x => x.Type == comboBoxTypeFilter.Text || x.Type is null).ToList();
            }
            Debug.WriteLine(numericUpDownPriceDown.Value);
            Debug.WriteLine(numericUpDownPriceUp.Value);
            filteredBooks = filteredBooks.Where(x => Decimal.Compare(x.Price, numericUpDownPriceDown.Value) >= 0).ToList();
            filteredBooks = filteredBooks.Where(x => Decimal.Compare(x.Price, numericUpDownPriceUp.Value) <= 0).ToList();
            filteredBooks = filteredBooks.Where(x => x.Pages >= numericUpDownPagesDown.Value).ToList();
            filteredBooks = filteredBooks.Where(x => x.Pages <= numericUpDownPagesUp.Value).ToList();

            bookBindingSource.DataSource = filteredBooks;
            FillComboboxes();
        }

        private decimal ToEUR(decimal price, string currency)
        {
            Logic.ExchangeOperations.LoadRates();
            if (!Logic.ExchangeOperations.FromCurrency.Contains(currency))
            {
                return 0;
            }
            else
            {
                return decimal.Round(price / Logic.ExchangeOperations.ExchangeRateToEuro[currency], 2);
            }
            /*foreach(var book in books)
            {
                if (!Logic.ExchangeOperations.FromCurrency.Contains(book.Currency))
                {
                    book.Price = new decimal(0.00);
                } else
                {
                    book.Price = decimal.Round(book.Price / Logic.ExchangeOperations.ExchangeRateToEuro[book.Currency], 2);
                }
            }*/
        }

        private void FillComboboxes()
        {
            comboBoxAuthorFilter.Items.Clear();
            comboBoxAuthorFilter.Items.AddRange(filteredBooks.Where(x => x.Author != null).Select(x => x.Author).Distinct().ToArray());
            

            comboBoxTitleFilter.Items.Clear();
            comboBoxTitleFilter.Items.AddRange(filteredBooks.Where(x => x.Title != null).Select(x => x.Title)?.Distinct().ToArray());
          
            comboBoxCurrencyFilter.Items.Clear();
            comboBoxCurrencyFilter.Items.AddRange(filteredBooks.Where(x => x.Currency != null).Select(x => x.Currency)?.Distinct().ToArray());

            comboBoxTypeFilter.Items.Clear();
            comboBoxTypeFilter.Items.AddRange(filteredBooks.Where(x => x.Type != null).Select(x => x.Type)?.Distinct().ToArray());

            numericUpDownPagesDown.Minimum = 0;
            numericUpDownPagesDown.Value = 0;
            numericUpDownPagesUp.Maximum = filteredBooks.Count > 0 ? filteredBooks.Max(x => x.Pages) : 0;
            numericUpDownPagesUp.Value = filteredBooks.Count > 0 ?  filteredBooks.Max(x => x.Pages) : 0;

            numericUpDownPriceDown.Minimum = 0;
            numericUpDownPriceDown.Value = 0;
            numericUpDownPriceUp.Maximum = filteredBooks.Count > 0 ? filteredBooks.Max(x => x.Price) : 0;
            numericUpDownPriceUp.Value = filteredBooks.Count > 0 ? filteredBooks.Max(x => x.Price) : 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Row 0:");
            Debug.WriteLine(books[0].Title);
            Book[] updated = new Book[books.Count];
            for (int i = 0; i < books.Count; i++)
            {
                updated[i] = books[i];
            }
            client.UpdateBook(updated);
        }

        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("Title: ");
                var selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
                sb.Append(selectedBook.Title);              
                if(client.BorrowBook(login, selectedBook))
                {
                    selectedBook.Borrowed = true;
                    MessageBox.Show(sb.ToString(), "Borrowed");
                } else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("Title: ");
                var selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
                if (selectedBook == null)
                {
                    return;
                }
                Debug.WriteLine("Book to return id: " + selectedBook.Id);
                sb.Append(selectedBook.Title);
                //
                if (client.DeleteBook(selectedBook))
                {
                    selectedBook.Borrowed = false;
                    MessageBox.Show(sb.ToString(), "Deleted");
                }
                //
                else
                {
                    MessageBox.Show("Error");
                }
                books.Remove(selectedBook);
                bookBindingSource.DataSource = new BindingSource(books, null);
            }
        }
    }
}
