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
            return (from c in Db.Carts
                    where c.userId == userId
                    select c).ToList();
        }

        public static void AddCart(Cart cart) {
            Db.Carts.Add(cart);
            Db.SaveChanges();
        }
    }
}