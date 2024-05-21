using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class TransactionDetailRepo {
        public static TransactionDetail GetTransactionDetail(int id) {
            return Db.Instance.TransactionDetails.FirstOrDefault((t) => t.transactionId.Equals(id));
        }

        public static List<TransactionDetail> GetAllTransactionDetails() {
            return (from t in Db.Instance.TransactionDetails
                    select t).ToList();
        }

        public static void AddTransactionDetail(TransactionDetail transactionDetail) {
            Db.Instance.TransactionDetails.Add(transactionDetail);
            Db.Instance.SaveChanges();
        }
    }
}