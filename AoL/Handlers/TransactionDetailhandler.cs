using AoL.Models;
using AoL.Repo;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class TransactionDetailHandler {
        public static List<TransactionDetail> GetAllTransactionDetails() {
            return TransactionDetailRepo.GetAllTransactionDetails();
        }
    }
}