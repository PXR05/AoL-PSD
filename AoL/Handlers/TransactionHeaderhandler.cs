using AoL.Models;
using AoL.Repo;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class TransactionHeaderHandler {
        public static List<TransactionHeader> GetAllTransactionHeaders() {
            return TransactionHeaderRepo.GetAllTransactionHeaders();
        }

        public static List<TransactionHeader> GetUserTransactionHeaders(int userId) {
            return TransactionHeaderRepo.GetUserTransactionHeaders(userId);
        }
    }
}