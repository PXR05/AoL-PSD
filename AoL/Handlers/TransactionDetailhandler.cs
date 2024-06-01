using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Handlers
{
    public static class TransactionDetailhandler
    {
        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return TransactionDetailRepo.GetAllTransactionDetails();
        }
    }
}