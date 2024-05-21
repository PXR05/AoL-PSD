using System.Collections.Generic;
using AoL.Handlers;
using AoL.Models;
using AoL.Repo;

namespace AoL.Controllers {
    public static class OrderController {
        private static string ValidateQuantity(int quantity) {
            return quantity <= 0 ? "Quantity must be greater than 0!" : "";
        }

        private static string ValidateMakeup(int makeupId) {
            return MakeupRepo.GetMakeup(makeupId) == null ? "Makeup not found!" : "";
        }

        public static string ClearCart(int userId) {
            var error = ItemHandler.ClearCart(userId);
            return error;
        }

        public static string Checkout(int userId, List<Cart> cart) {
            var error = ItemHandler.Checkout(userId, cart);
            return error;
        }

        public static string AddToCart(int userId, int makeupId, int quantity) {
            var qtyError = ValidateQuantity(quantity);
            if (qtyError != "") return qtyError;
            var makeupError = ValidateMakeup(makeupId);
            if (makeupError != "") return makeupError;
            var error = ItemHandler.AddToCart(userId, makeupId, quantity);
            return error;
        }
    }
}