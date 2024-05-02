using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public class UserRepo {
        private readonly AoL_DBEntities _db = Db.Instance;

        public User GetUser(string username, string password) {
            return (from u in _db.Users
                    where u.username == username && u.password == password
                    select u).FirstOrDefault();
        }

        public User GetUser(int id) {
            return (from u in _db.Users
                    where u.id == id
                    select u).FirstOrDefault();
        }

        public List<User> GetAllUsers() {
            return (from u in _db.Users
                    select u).ToList();
        }

        public void AddUser(User user) {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public (string, User) UpdateUser(int id, string username, string email, string gender, string dob) {
            var user = (from u in _db.Users
                        where u.id == id
                        select u).FirstOrDefault();

            if (user == null) {
                return ("User not found!", null);
            }

            user.username = username;
            user.email = email;
            user.gender = gender;
            user.dob = DateTime.Parse(dob).Date;
            _db.SaveChanges();

            return ("", user);
        }
    }
}