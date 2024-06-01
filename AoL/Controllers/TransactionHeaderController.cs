using AoL.Handlers;
using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Controllers
{
    public static class TransactionHeaderController
    {
        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return TransactionHeaderhandler.GetAllTransactionHeaders();
        }
        public static List<TransactionHeader> GetUserTransactionHeaders(int userId)
        {
            return TransactionHeaderhandler.GetUserTransactionHeaders(userId);
        }
    }
}