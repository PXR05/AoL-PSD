using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Factories {
    public static class TransactionFactory {
        private static int NewHeaderId() {
            var maxId = TransactionHeaderRepo.GetAllTransactionHeaders();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }
        private static int NewDetailId() {
            var maxId = TransactionDetailRepo.GetAllTransactionDetails();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static (TransactionHeader, List<TransactionDetail>) CreateTransaction(int userId, List<Cart> cart, string status) {
            var header = new TransactionHeader {
                id = NewHeaderId(),
                userId = userId,
                status = status,
                transactionDate = DateTime.Now
            };
            var details = new List<TransactionDetail>();
            var i = 0;
            foreach (var c in cart) {
                details.Add(new TransactionDetail {
                    id = NewDetailId() + i,
                    transactionId = header.id,
                    makeupId = c.makeupId,
                    quantity = c.quantity
                });
                i++;
            }

            return (header, details);
        }
    }
}