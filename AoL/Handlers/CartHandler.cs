using AoL.Models;
using AoL.Repo;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class CartHandler {
        public static List<Cart> GetAllCarts() {
            return CartRepo.GetAllCarts();
        }
    }
}