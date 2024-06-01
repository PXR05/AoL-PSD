using AoL.Handlers;
using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Controllers
{
    public static class TransactionDetailController
    {
        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return TransactionDetailHandler.GetAllTransactionDetails();
        }
    }
}