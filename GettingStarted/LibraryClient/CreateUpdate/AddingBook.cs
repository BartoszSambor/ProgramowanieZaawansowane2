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

namespace LibraryClient.CreateUpdate
{
    public partial class AddingBook : Form
    {
        private BookCreator bk;
        private CalculatorClient client;
        public AddingBook()
        {
            client = new CalculatorClient();
            bk = new BookCreator(client);
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(!bk.CreateBook(new Book()
            {
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                Price = Decimal.Parse(numericUpDownPrice.Text),
                Type = textBoxType.Text,
                Currency = textBoxCurrency.Text,
                Pages = Int32.Parse(numericUpDownPrages.Text)
            }))
            {
                MessageBox.Show(bk.ErrorMessage);
            }
        }
    }
}
