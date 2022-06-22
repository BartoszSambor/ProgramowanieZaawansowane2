using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace UsersServer
{
    public partial class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Librarin> Librarians { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
