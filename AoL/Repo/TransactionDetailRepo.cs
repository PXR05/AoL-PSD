using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class TransactionDetailRepo {

        public static List<TransactionDetail> GetTransactionDetails(int id) {
            return Db.Instance.TransactionDetails.Where((t) => t.transactionId.Equals(id)).ToList();
        }

        public static List<TransactionDetail> GetAllTransactionDetails() {
            return (from t in Db.Instance.TransactionDetails
                    select t).ToList();
        }

        public static void AddTransactionDetails(List<TransactionDetail> transactionDetails) {
            foreach (var detail in transactionDetails) {
                Db.Instance.TransactionDetails.Add(detail);
            }
            Db.Instance.SaveChanges();
        }
    }
}