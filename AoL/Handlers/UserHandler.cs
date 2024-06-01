using AoL.Models;
using AoL.Repo;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class UserHandler {
        public static List<User> GetAllUsers() {
            return UserRepo.GetAllUsers();
        }

        public static User GetUser(int id) {
            return UserRepo.GetUser(id);
        }
    }
}