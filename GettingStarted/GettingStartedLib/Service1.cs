using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ServiceModel;
using System.Windows.Forms;

namespace GettingStartedLib
{
    public class CalculatorService : ICalculator
    {
        int k = 9;
        public TextBox tb;
        

        public double Add(double n1, double n2)
        {
            k += 1;
            double result = n1 + n2 + k;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            // Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            string newText = "abc";
            
            if(tb != null)
            {
                tb.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    tb.Text = newText;
                });
            }

            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }
        
        public List<Book> GetBooks()
        {
            // Write to console about querying books
            Console.WriteLine("Querying books");

            using (var db = new BookContext())
            {
                Console.WriteLine("Querying books finished");
                return db.Books.ToListAsync().Result;
            }
        }

        public bool InsertBook(Book book)
        {
            Console.WriteLine("Adding books");
            using (var db = new BookContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
                Console.WriteLine("Adding books finished");
            }

            return true;
        }

        public bool UpdateBook(List<Book> book)
        {
            Console.WriteLine("Updating books");
            using (var db = new BookContext())
            {
                foreach (var b in book)
                {
                    db.Books.Attach(b);
                    db.Entry(b).State = EntityState.Modified;
                }               
                db.SaveChanges();
                Console.WriteLine("Updating books finished");
            }

            return true;
        }

        private void Copy(Book target, Book book)
        {
            target.Author = book.Author;
            target.Title = book.Title;
            target.Price = book.Price;
            target.Currency = book.Currency;
            target.Type = book.Type;
            target.Pages = book.Pages;
        }


    }
}