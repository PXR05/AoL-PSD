using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public abstract class UserRepo {
        private static readonly AoL_DBEntities Db = Repo.Db.Instance;

        public static User GetUser(string username, string password) {
            return (from u in Db.Users
                    where u.username == username && u.password == password
                    select u).FirstOrDefault();
        }

        public static User GetUser(int id) {
            return (from u in Db.Users
                    where u.id == id
                    select u).FirstOrDefault();
        }

        public static List<User> GetAllUsers() {
            return (from u in Db.Users
                    select u).ToList();
        }

        public static void AddUser(User user) {
            Db.Users.Add(user);
            Db.SaveChanges();
        }

        public static (string, User) UpdateUser(int id, string username, string email, string gender, string dob) {
            var user = (from u in Db.Users
                        where u.id == id
                        select u).FirstOrDefault();

            if (user == null) {
                return ("User not found!", null);
            }

            user.username = username;
            user.email = email;
            user.gender = gender;
            user.dob = DateTime.Parse(dob).Date;
            Db.SaveChanges();

            return ("", user);
        }

        public static void UpdatePassword(int id, string password) {
            var user = (from u in Db.Users
                        where u.id == id
                        select u).FirstOrDefault();

            if (user != null) user.password = password;
            Db.SaveChanges();
        }
    }
}