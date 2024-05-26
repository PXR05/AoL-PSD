using AoL.Models;

namespace AoL.Factories {
    public static class TransactionDetailFactory {
        public static TransactionDetail CreateTransactionDetail(int transactionId, int makeupId, int quantity) {
            return new TransactionDetail {
                transactionId = transactionId,
                makeupId = makeupId,
                quantity = quantity
            };
        }
    }
}