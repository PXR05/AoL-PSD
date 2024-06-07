using AoL.Factories;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class OrderHandler {
        public static string ClearCart(int userId) {
            try {
                CartRepo.ClearCart(userId);
            } catch (Exception e) {
                return e.Message;
            }
            return "";
        }

        public static string Checkout(int userId, List<Cart> cart) {
            var (header, details) = TransactionFactory.CreateTransaction(userId, cart, "unhandled");

            try {
                TransactionHeaderRepo.AddTransactionHeader(header);
                TransactionDetailRepo.AddTransactionDetails(details);
            } catch (Exception e) {
                return e.Message + e.StackTrace;
            }

            return "";
        }

        public static (TransactionHeader, List<TransactionDetail>, string) GetTransaction(int id) {
            var header = TransactionHeaderRepo.GetTransactionHeader(id);
            if (header == null) {
                return (null, null, "Transaction not found!");
            }

            var detail = TransactionDetailRepo.GetTransactionDetails(id);
            return detail == null ? (null, null, "Transaction detail not found!") : ((TransactionHeader, List<TransactionDetail>, string))(header, detail, "");
        }

        public static string HandleTransaction(int id, string status) {
            try {
                TransactionHeaderRepo.UpdateTransactionHeader(id, status);
            } catch (Exception e) {
                return e.Message;
            }

            return "";
        }

        public static string AddToCart(int userId, int makeupId, int qty) {
            var cart = CartFactory.CreateCart(userId, makeupId, qty);
            try {
                CartRepo.AddCart(cart);
            } catch (Exception e) {
                return e.Message;
            }
            return "";
        }
    }
}