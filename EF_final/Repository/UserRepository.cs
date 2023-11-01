using EF_final.Models;
using EF_final.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_final.Repository
{
    public class UserRepository : IUserRepository
    {
        private AppContext db;
        public UserRepository(AppContext appContext)
        {
            db = appContext;
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public void AddUser(User user)
        {
            db.Add(user);
        }

        public void UpdateUser(int id, string name)
        {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.Name = name;
                }
        }

        public void DeleteUser(User user)
        {
            db.Remove(user);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public int UserBooksCount(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                return user.Books.Count();
            }
            return 0;
        }
    }
}
