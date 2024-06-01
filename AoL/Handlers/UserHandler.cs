using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Handlers
{
    public class UserHandler
    {
        public static List<User> GetAllUsers()
        {
            return UserRepo.GetAllUsers();
        }

        public static User GetUser(int id)
        {
            return UserRepo.GetUser(id);
        }
    }
}