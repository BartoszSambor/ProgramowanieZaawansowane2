using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace GettingStartedLib
{

    public class CalculatorService : ICalculator
    {

        public List<Book> GetBooks()
        {
            // Write to console about querying books
            Console.WriteLine("Querying books");

            using (var db = new BookContext())
            {
                Console.WriteLine("Querying books finished");
                return db.Books.ToList();
            }
        }

        public bool InsertBook(Book book)
        {
            Console.WriteLine("Adding books");
            using (var db = new BookContext())
            {
                db.Books.Add(book);
                var usersToNotify = db.Subscriptions.Where(x => x.Type == book.Type)?.Select(x => x.User).ToList<string>();
                foreach(var nick in usersToNotify)
                {
                    db.Notifications.Add(new Notification() { BookId = book.Id, Time = DateTime.Now, User = nick });
                }
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

        public List<Book> GetBorrowedBooks(string login)
        {
            using (var db = new BookContext())
            {
                return db.BorrowedBooks.Where(x => x.User == login).Select(x => x.Book).ToList<Book>();
            }
        }
        public List<BorrowedElem> GetBorrowedBooksWithTime(string login)
        {
            using (var db = new BookContext())
            {
                return db.BorrowedBooks.Where(x => x.User == login).Include(x => x.Book).Select(x => x).ToList<BorrowedElem>();
            }
        }
        
        public bool BorrowBook(string login, Book book)
        {
            if (book.Borrowed)
            {
                return false;
            }
            using (var db = new BookContext())
            {
                db.BorrowedBooks.Add(new BorrowedElem() { User = login, Book = book, BorrowTime = DateTime.Now, ReturnDeadline = DateTime.Now.AddDays(30)});
                book.Borrowed = true;
                db.Books.Attach(book);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                Debug.WriteLine("Borrowed book");
            }
            return true;
        }

        public List<BorrowedElem> GetBorrowedBooksAll()
        {
            using (var db = new BookContext())
            {
                return db.BorrowedBooks.Select(x => x).Include(x => x.Book).ToList<BorrowedElem>();
            }
        }

        public bool ReturnBook(string login, Book book)
        {
            try {
                    //This work but delete first book with that id only
                using (var db = new BookContext())
                {
                    var borrowed = db.BorrowedBooks.Where(x => x.Book.Id == book.Id).First();
                    db.BorrowedBooks.Remove(borrowed);
                    db.History.Add(new BorrowedHistory() { 
                        User = login, BookId = book.Id, BorrowTime = borrowed.BorrowTime, ReturnDeadline = DateTime.Now 
                    });

                    var bookToUpdate = db.Books.Where(x => x.Id == book.Id).First();
                    bookToUpdate.Borrowed = false;
                    db.SaveChanges();
                    return true;
                    }
                }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            Debug.WriteLine("End End End sh");
            return false;
        }

        public bool DeleteBook(Book book)
        {
            using (var db = new BookContext())
            {
                db.BorrowedBooks.RemoveRange(db.BorrowedBooks.Where(x => x.Book.Id == book.Id));
                db.History.RemoveRange(db.History.Where(x => x.BookId == book.Id));
                db.Notifications.RemoveRange(db.Notifications.Where(x => x.BookId == book.Id));
                db.Books.Remove(db.Books.Where(x => x.Id == book.Id).First());
                db.SaveChanges();
            }
            return true;
        }

        public List<BorrowedHistory> GetHistory(string login)
        {
            using (var db = new BookContext())
            {
                return db.History.Where(x => x.User == login).Include(x => x.Book).Select(x => x).ToList<BorrowedHistory>();
            }
        }

        public List<Notification> GetNotifications(string login)
        {
            using (var db = new BookContext())
            {
                return db.Notifications.Where(x => x.User == login).Include(x => x.Book).Select(x => x).ToList<Notification>();
            }
        }

        public List<Notification> GetNotificationsAll()
        {
            using (var db = new BookContext())
            {
                return db.Notifications.Include(x => x.Book).Select(x => x).ToList<Notification>();
            }
        }

        public List<Subscription> GetSubscriptionsAll()
        {
            using (var db = new BookContext())
            {
                return db.Subscriptions.Select(x => x).ToList<Subscription>();
            }
        }

        public bool SubscribeAndClear(string login, List<string> types)
        {
            using (var db = new BookContext())
            {
                // remove old
                db.Subscriptions.RemoveRange(db.Subscriptions.Where(x => x.User == login));
                db.SaveChanges();
                // add new
                foreach(var type in types)
                {
                    db.Subscriptions.Add(new Subscription()
                    {
                        User = login,
                        Type = type
                    });
                }
                db.SaveChanges();
            }
            return true;
        }

        public List<string> GetSubscriptions(string login)
        {
            using (var db = new BookContext())
            {
                return db.Subscriptions.Where(x => x.User == login).Select(x => x.Type).ToList<string>();
            }
        }

        public bool ClearNotifications(string login)
        {
            using (var db = new BookContext())
            {
                db.Notifications.RemoveRange(db.Notifications.Where(x => x.User == login));
                db.SaveChanges();
            }
            return true;
        }
    }
}