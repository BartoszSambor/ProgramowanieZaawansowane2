using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UsersServer
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class UsersServer : IUserServer
    {
        public bool CreateUser(string login, string password, string permissions)
        {
            using (var db = new UserContext())
            {
                if (permissions == "User")
                {
                    if(db.Users.Any(u => u.Login.Equals(login)))
                    {
                        return false;
                    }
                    db.Users.Add(new User { Login = login, Password = password });
                } 
                else if (permissions == "Librarian")
                {
                    if (db.Librarians.Any(u => u.Login.Equals(login)))
                    {
                        return false;
                    }
                    db.Librarians.Add(new Librarin { Login = login, Password = password });
                }
                else if (permissions == "Admin")
                {
                    if (db.Admins.Any(u => u.Login.Equals(login)))
                    {
                        return false;
                    }
                    db.Admins.Add(new Admin { Login = login, Password = password });
                }
                db.SaveChanges();
                Console.WriteLine("Adding books finished");
                return true;
            }
        }

        public List<Admin> GetAdmins()
        {
            using (var db = new UserContext())
            {
                return db.Admins.ToList();
            }
        }

        public List<Librarin> GetLibrarians()
        {
            using (var db = new UserContext())
            {
                return db.Librarians.ToList();
            }
        }

        public List<User> GetUsers()
        {
            using (var db = new UserContext())
            {
                return db.Users.ToList();
            }
        }

        public bool Login(string login, string password, string permissions)
        {
            using (var db = new UserContext())
            {
                if(permissions == "User")
                {
                    if (db.Users.Any(u => u.Login.Equals(login) && u.Password.Equals(password)))
                    {
                        return true;
                    }
                }
                else if (permissions == "Librarian")
                {
                    if (db.Librarians.Any(u => u.Login.Equals(login) && u.Password.Equals(password)))
                    {
                        return true;
                    }
                }
                else if (permissions == "Admin")
                {
                    if (db.Admins.Any(u => u.Login.Equals(login) && u.Password.Equals(password)))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
