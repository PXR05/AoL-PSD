using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class CartRepo {
        public static Cart GetCart(int id) {
            return (from c in Db.Instance.Carts
                    where c.id == id
                    select c).FirstOrDefault();
        }

        public static List<Cart> GetAllCarts() {
            return (from c in Db.Instance.Carts
                    select c).ToList();
        }

        public static List<Cart> GetCartByUserId(int userId) {
            return Db.Instance.Carts.Where((c) => c.userId == userId).ToList();
        }

        public static void ClearCart(int userId) {
            var carts = GetCartByUserId(userId);
            foreach (var cart in carts) {
                Db.Instance.Carts.Remove(cart);
            }
            System.Diagnostics.Debug.WriteLine("Carts cleared!");
            Db.Instance.SaveChanges();
        }

        public static void AddCart(Cart cart) {
            Db.Instance.Carts.Add(cart);
            Db.Instance.SaveChanges();
        }
    }
}