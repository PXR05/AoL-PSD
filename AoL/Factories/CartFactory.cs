﻿using AoL.Models;
using AoL.Repo;
using System.Linq;

namespace AoL.Factories {
    public static class CartFactory {
        private static int NewId() {
            var maxId = CartRepo.GetAllCarts();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static Cart CreateCart(int userId, int makeupId, int qty) {
            return new Cart {
                id = NewId(),
                userId = userId,
                makeupId = makeupId,
                quantity = qty,
            };
        }
    }
}