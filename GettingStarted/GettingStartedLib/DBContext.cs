using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GettingStartedLib
{
    public partial class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedElem> BorrowedBooks { get; set; }
        public DbSet<BorrowedHistory> History { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Subscription> Subscriptions{ get; set; }
    }
    
}
