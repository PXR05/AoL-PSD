using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public class CartRepo {
        private readonly AoL_DBEntities _db = Db.Instance;

        public Cart GetCart(int id) {
            return (from c in _db.Carts
                    where c.id == id
                    select c).FirstOrDefault();
        }

        public List<Cart> GetAllCarts() {
            return (from c in _db.Carts
                    select c).ToList();
        }

        public List<Cart> GetCartByUserId(int userId) {
            return (from c in _db.Carts
                    where c.userId == userId
                    select c).ToList();
        }

        public void AddCart(Cart cart) {
            _db.Carts.Add(cart);
            _db.SaveChanges();
        }
    }
}