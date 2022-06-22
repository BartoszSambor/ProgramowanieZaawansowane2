using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedLib
{
    
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public Decimal Price { get; set; }
        public string Currency { get; set; }
        public int Pages { get; set; }      
        public bool Borrowed { get; set; }
    }

    public class BorrowedElem
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime? BorrowTime { get; set; }
        public DateTime? ReturnDeadline { get; set; }
    }
    public class BorrowedHistory
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime? BorrowTime { get; set; }
        public DateTime? ReturnDeadline { get; set; }
    }

    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime? Time { get; set; }
    }
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public string Type { get; set; }
    }


}
