using AoL.Models;
using AoL.Repo;
using System;
using System.Linq;

namespace AoL.Factories {
    public static class TransactionFactory {
        private static int NewId() {
            var maxId = TransactionHeaderRepo.GetAllTransactionHeaders();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static (TransactionHeader, TransactionDetail) CreateTransaction(int userId, Cart cart, string status) {
            var header = new TransactionHeader {
                id = NewId(),
                userId = userId,
                status = status,
                transactionDate = DateTime.Now
            };
            var detail = new TransactionDetail {
                transactionId = header.id,
                makeupId = cart.makeupId,
                quantity = cart.quantity
            };

            return (header, detail);
        }
    }
}