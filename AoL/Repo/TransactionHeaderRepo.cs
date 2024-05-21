using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class TransactionHeaderRepo {
        public static TransactionHeader GetTransactionHeader(int id) {
            return Db.Instance.TransactionHeaders.FirstOrDefault((t) => t.id.Equals(id));
        }

        public static List<TransactionHeader> GetUserTransactionHeaders(int userId) {
            return (from t in Db.Instance.TransactionHeaders
                    where t.userId == userId
                    select t).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionHeaders() {
            return (from t in Db.Instance.TransactionHeaders
                    select t).ToList();
        }

        public static void AddTransactionHeader(TransactionHeader transactionHeader) {
            Db.Instance.TransactionHeaders.Add(transactionHeader);
            Db.Instance.SaveChanges();
        }
    }
}