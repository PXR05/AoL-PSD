using AoL.Factories;
using AoL.Models;
using AoL.Repo;

namespace AoL.Handlers {
    public class CartHandler {
        private readonly CartRepo _cartRepo = new CartRepo();
        private readonly CartFactory _cartFactory = new CartFactory();
        private readonly MakeupRepo _makeupRepo = new MakeupRepo();

        public (string, Cart) AddToCart(int userId, int makeupId, int qty) {
            if (qty <= 0) {
                return ("Quantity must be greater than 0", null);
            }
            var makeup = _makeupRepo.GetMakeup(makeupId);
            if (makeup == null) {
                return ("Makeup not found", null);
            }
            var cart = _cartFactory.CreateCart(userId, makeupId, qty);
            _cartRepo.AddCart(cart);

            return ("", cart);
        }
    }
}