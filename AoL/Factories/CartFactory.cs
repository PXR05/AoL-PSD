using AoL.Models;
using AoL.Repo;
using System.Linq;

namespace AoL.Factories {
    public class CartFactory {
        private readonly CartRepo _cartRepo = new CartRepo();

        private int NewId() {
            var maxId = _cartRepo.GetAllCarts();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public Cart CreateCart(int userId, int makeupId, int qty) {
            return new Cart {
                id = NewId(),
                userId = userId,
                makeupId = makeupId,
                quantity = qty,
            };
        }
    }
}