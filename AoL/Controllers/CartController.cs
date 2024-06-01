using AoL.Handlers;
using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Controllers
{
    public class CartController
    {
        public static List<Cart> GetAllCarts()
        {
            return CartHandler.GetAllCarts();
        }
    }
}