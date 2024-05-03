using AoL.Factories;
using AoL.Models;
using AoL.Repo;
using System;
using System.Web;

namespace AoL.Handlers {
    public static class UserHandler {

        public static string RegisterUser(string username, string email, string password, string dob,
            string gender) {

            var user = UserFactory.CreateUser(username, email, password, gender, dob);
            try {
                UserRepo.AddUser(user);
            } catch (Exception e) {
                return e.Message;
            }

            return "";
        }

        private static void SaveSession(User user) {
            HttpContext.Current.Session["User"] = user.username;
            HttpContext.Current.Session["Role"] = user.role;
            HttpContext.Current.Session["Id"] = user.id;
        }

        public static string LoginUser(string username, string password) {
            var user = UserRepo.GetUser(username, password);

            if (user == null) return "Invalid username or password!";
            SaveSession(user);
            return "";
        }

        public static string UpdateUser(int id, string username, string email, string gender, string dob) {
            var (updateError, user) = UserRepo.UpdateUser(id, username, email, gender, dob);
            SaveSession(user);
            return updateError;
        }

        public static string UpdatePassword(int id, string oldPass, string newPass) {
            var user = UserRepo.GetUser(id);
            if (user == null) return "User not found!";
            if (oldPass != user.password) return "Incorrect password!";
            UserRepo.UpdatePassword(id, newPass);
            return "";
        }
    }
}