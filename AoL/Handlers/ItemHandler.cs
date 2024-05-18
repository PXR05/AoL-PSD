using AoL.Factories;
using AoL.Repo;
using System;

namespace AoL.Handlers {
    public static class ItemHandler {
        public static string ClearCart(int userId) {
            try {
                CartRepo.ClearCart(userId);
            } catch (Exception e) {
                return e.Message;
            }
            return "";
        }

        public static string AddToCart(int userId, int makeupId, int qty) {
            var cart = CartFactory.CreateCart(userId, makeupId, qty);
            try {
                CartRepo.AddCart(cart);
            } catch (Exception e) {
                return e.Message;
            }
            return "";
        }
    }
}