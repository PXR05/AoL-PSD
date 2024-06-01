using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Handlers
{
    public class CartHandler
    {
        public static List<Cart> GetAllCarts()
        {
            return CartRepo.GetAllCarts();
        }
    }
}