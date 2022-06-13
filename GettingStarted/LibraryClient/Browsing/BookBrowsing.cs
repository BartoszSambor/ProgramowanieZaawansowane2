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

namespace LibraryClient
{
    public partial class BookBrowsing : Form
    {
        CalculatorClient client = new CalculatorClient();
        List<Book> books;
        List<Book> filteredBooks;
        public BookBrowsing(bool readOnly = true)
        {
            InitializeComponent();
            dataGridView1.ReadOnly = readOnly;
            if (readOnly)
            {
                buttonSave.Visible = false;
            }
        }

        private void BookBrowsing_Load(object sender, EventArgs e)
        {
            
            books = client.GetBooks().ToList<Book>();
            filteredBooks = books;
            bookBindingSource.DataSource = new BindingSource(filteredBooks, null);
            FillComboboxes();
            
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
                    filteredBooks = filteredBooks.Where(x => x.Title == comboBoxTitleFilter.Text).ToList();
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
            numericUpDownPagesUp.Maximum = filteredBooks.Max(x => x.Pages);
            numericUpDownPagesUp.Value = filteredBooks.Max(x => x.Pages);

            numericUpDownPriceDown.Minimum = 0;
            numericUpDownPriceDown.Value = 0;
            numericUpDownPriceUp.Maximum = filteredBooks.Max(x => x.Price);
            numericUpDownPriceUp.Value = filteredBooks.Max(x => x.Price);
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
