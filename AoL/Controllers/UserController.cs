using AoL.Handlers;
using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Controllers
{
    public class UserController
    {
        public static List<User> GetAllUsers()
        {
            return UserHandler.GetAllUsers();
        }

        public static User GetUser(int id)
        {
            return UserHandler.GetUser(id);
        }

    }
}