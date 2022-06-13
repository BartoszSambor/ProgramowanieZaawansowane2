using LibraryClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClient.CreateUpdate
{
    internal class BookCreator
    {
        private CalculatorClient client;
        private string errorMessage;
        public BookCreator(CalculatorClient client)
        {
            this.client = client;
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        public bool CreateBook(Book book)
        {
            if (book == null)
            {
                errorMessage = "Book is null";
                return false;
            }
            if (string.IsNullOrEmpty(book.Title))
            {
                errorMessage = "Title is null";
                return false;
            }
            if (string.IsNullOrEmpty(book.Author))
            {
                errorMessage = "Author is null";
                return false;
            }
            if (book.Price <= 0)
            {
                errorMessage = "Price is 0";
                return false;
            }
            if (book.Pages <= 0)
            {
                errorMessage = "Pages is 0 or below";
                return false;
            }
            bool result = client.InsertBook(book);
            if (!result)
            {
                errorMessage = "Can't add book";
            }
            return result;
        }

    }
}
