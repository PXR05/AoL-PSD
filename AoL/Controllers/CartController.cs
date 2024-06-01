using AoL.Handlers;
using AoL.Models;
using System.Collections.Generic;

namespace AoL.Controllers {
    public static class CartController {
        public static List<Cart> GetAllCarts() {
            return CartHandler.GetAllCarts();
        }
    }
}