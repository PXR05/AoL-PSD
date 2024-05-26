using AoL.Models;
using AoL.Repo;
using System;
using System.Linq;

namespace AoL.Factories {
    public static class TransactionHeaderFactory {
        private static int NewId() {
            var maxId = TransactionHeaderRepo.GetAllTransactionHeaders();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static TransactionHeader CreateTransactionHeader(int userId, string status) {
            var header = new TransactionHeader {
                id = NewId(),
                userId = userId,
                status = status,
                transactionDate = DateTime.Now
            };

            return header;
        }
    }
}