using AoL.Controllers;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Views {
    public partial class History : System.Web.UI.Page {
        protected bool isAdmin = false;
        protected List<TransactionHeader> Transactions = new List<TransactionHeader>();
        protected TransactionHeader SelectedHeader = null;
        protected TransactionDetail SelectedDetail = null;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (Session["Role"].ToString() != "user") {
                // Admin can see all transactions
                isAdmin = true;
                Transactions = TransactionHeaderRepo.GetAllTransactionHeaders();
            } else {
                var userId = int.Parse(Session["Id"].ToString());
                Transactions = TransactionHeaderRepo.GetUserTransactionHeaders(userId);
            }

            var id = int.Parse(Request.Params.Get("id") ?? "-1");

            if (id == -1) {
                SelectedHeader = null;
                SelectedDetail = null;
                return;
            }

            string error;
            (SelectedHeader, SelectedDetail, error) = OrderController.GetTransaction(id);

            if (error == "") return;

            if (SelectedHeader.userId != int.Parse(Session["Id"].ToString())) {
                // User can only see their own transactions
                SelectedHeader = null;
                SelectedDetail = null;
                return;
            }

            SelectedHeader = null;
            SelectedDetail = null;
            Error.Text = error;
        }
    }
}