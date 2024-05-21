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
            foreach (var item in cart) {
                var makeup = MakeupRepo.GetMakeup(item.makeupId);
                if (makeup == null) {
                    return "Makeup not found!";
                }

                var (header, details) = TransactionFactory.CreateTransaction(userId, item, "unhandled");

                try {
                    TransactionHeaderRepo.AddTransactionHeader(header);
                    TransactionDetailRepo.AddTransactionDetail(details);
                } catch (Exception e) {
                    return e.Message;
                }
            }

            return ClearCart(userId);
        }

        public static (TransactionHeader, TransactionDetail, string) GetTransaction(int id) {
            var header = TransactionHeaderRepo.GetTransactionHeader(id);
            if (header == null) {
                return (null, null, "Transaction not found!");
            }

            var detail = TransactionDetailRepo.GetTransactionDetail(id);
            return detail == null ? (null, null, "Transaction detail not found!") : ((TransactionHeader, TransactionDetail, string))(header, detail, "");
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