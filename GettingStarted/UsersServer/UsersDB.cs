using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersServer
{
        public class User
        {
            [Key]
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }
        public class Librarin
        {
            [Key]
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class Admin
        {
            [Key]
            public int Id { get; set; }
        
            public string Login { get; set; }
            public string Password { get; set; }
        }

}
