using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public abstract class UserRepo {
        public static User GetUser(string username, string password) {
            return (from u in Db.Instance.Users
                    where u.username == username && u.password == password
                    select u).FirstOrDefault();
        }

        public static User GetUser(int id) {
            return (from u in Db.Instance.Users
                    where u.id == id
                    select u).FirstOrDefault();
        }

        public static List<User> GetAllUsers() {
            return (from u in Db.Instance.Users
                    select u).ToList();
        }

        public static void AddUser(User user) {
            Db.Instance.Users.Add(user);
            Db.Instance.SaveChanges();
        }

        public static (string, User) UpdateUser(int id, string username, string email, string gender, string dob) {
            var user = (from u in Db.Instance.Users
                        where u.id == id
                        select u).FirstOrDefault();

            if (user == null) {
                return ("User not found!", null);
            }

            user.username = username;
            user.email = email;
            user.gender = gender;
            user.dob = DateTime.Parse(dob).Date;
            Db.Instance.SaveChanges();

            return ("", user);
        }

        public static void UpdatePassword(int id, string password) {
            var user = (from u in Db.Instance.Users
                        where u.id == id
                        select u).FirstOrDefault();

            if (user != null) user.password = password;
            Db.Instance.SaveChanges();
        }
    }
}