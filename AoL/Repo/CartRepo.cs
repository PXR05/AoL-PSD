using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class CartRepo {
        private static readonly AoL_DBEntities Db = Repo.Db.Instance;

        public static Cart GetCart(int id) {
            return (from c in Db.Carts
                    where c.id == id
                    select c).FirstOrDefault();
        }

        public static List<Cart> GetAllCarts() {
            return (from c in Db.Carts
                    select c).ToList();
        }

        public static List<Cart> GetCartByUserId(int userId) {
            return Db.Carts.Where((c) => c.userId == userId).ToList();
        }

        public static void ClearCart(int userId) {
            var carts = GetCartByUserId(userId);
            foreach (var cart in carts) {
                Db.Carts.Remove(cart);
            }
            System.Diagnostics.Debug.WriteLine("Carts cleared!");
            Db.SaveChanges();
        }

        public static void AddCart(Cart cart) {
            Db.Carts.Add(cart);
            Db.SaveChanges();
        }
    }
}