using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Handlers
{
    public static class TransactionHeaderhandler
    {
        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return TransactionHeaderRepo.GetAllTransactionHeaders();
        }

        public static List<TransactionHeader> GetUserTransactionHeaders(int userId)
        {
            return TransactionHeaderRepo.GetUserTransactionHeaders(userId);
        }
    }
}