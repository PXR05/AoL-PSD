using AoL.Models;
using AoL.Repo;
using System;
using System.Linq;

namespace AoL.Factories {
    public class UserFactory {
        private readonly UserRepo _userRepo = new UserRepo();

        private int NewId() {
            var maxId = _userRepo.GetAllUsers().Max(x => x.id);
            return maxId + 1;
        }

        public User CreateUser(string username, string email, string password, string gender, string dob) {
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