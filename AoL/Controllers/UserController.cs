using AoL.Handlers;
using AoL.Models;
using System.Collections.Generic;

namespace AoL.Controllers {
    public static class UserController {
        public static List<User> GetAllUsers() {
            return UserHandler.GetAllUsers();
        }

        public static User GetUser(int id) {
            return UserHandler.GetUser(id);
        }

    }
}