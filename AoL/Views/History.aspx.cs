using AoL.Controllers;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Views {
    public partial class History : System.Web.UI.Page {
        protected List<TransactionHeader> Transactions = new List<TransactionHeader>();
        protected TransactionHeader selectedHeader = null;
        protected TransactionDetail selectedDetail = null;
        protected Makeup selectedMakeup = null;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            var userId = int.Parse(Session["Id"].ToString());
            Transactions = TransactionHeaderRepo.GetUserTransactionHeaders(userId);

            var id = Request.Params.Get("id");
            if (id == null) {
                selectedHeader = null;
                selectedDetail = null;
                selectedMakeup = null;
                return;
            }

            var error = "";
            (selectedHeader, selectedDetail, error) = OrderController.GetTransaction(int.Parse(id));

            if (error != "") {
                selectedHeader = null;
                selectedDetail = null;
                selectedMakeup = null;
                Error.Text = error;
                return;
            }

            selectedMakeup = selectedDetail.Makeup;
        }
    }
}