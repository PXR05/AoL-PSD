using AoL.Models;
using AoL.Repo;
using System;
using System.Linq;

namespace AoL.Factories {
    public static class UserFactory {

        private static int NewId() {
            var maxId = UserRepo.GetAllUsers();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static User CreateUser(string username, string email, string password, string gender, string dob) {
            return new User {
                id = NewId(),
                username = username,
                email = email,
                password = password,
                gender = gender,
                role = "user",
                dob = DateTime.Parse(dob).Date,
            };
        }
    }
}