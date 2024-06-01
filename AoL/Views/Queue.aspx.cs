using AoL.Controllers;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Views {
    public partial class Queue1 : System.Web.UI.Page {
        protected List<TransactionHeader> Transactions = new List<TransactionHeader>();

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }

            Transactions = TransactionHeaderController.GetAllTransactionHeaders();

            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            if (id == -1) {
                return;
            }

            HandleTransaction(id);
        }

        private void HandleTransaction(int id) {
            OrderController.HandleTransaction(id, "handled");
            Response.Redirect("~/Views/Queue.aspx", true);
        }
    }
}