using AoL.Controllers;
using AoL.DataSet;
using AoL.Models;
using AoL.Reportt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Views {
    public partial class Report : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }

            var report = new CrystalReport2();
            CrystalReportViewer1.ReportSource = report;
            var data = GetData(TransactionHeaderController.GetAllTransactionHeaders(), TransactionDetailController.GetAllTransactionDetails());
            report.SetDataSource(data);

        }
        private static DataSet1 GetData(List<TransactionHeader> transactionHeaders, List<TransactionDetail> transactionDetails) {
            var data = new DataSet1();
            var header = data.transactions;
            var details = data.transactions_details;
            foreach (var th in transactionHeaders) {
                var hrow = header.NewRow();
                hrow["transaction_id"] = th.id;
                hrow["user_id"] = th.userId;
                hrow["transaction_date"] = th.transactionDate;
                hrow["status"] = th.status;
                hrow["grand_total"] = th.TransactionDetails.Sum(d => d.quantity * d.Makeup.price);
                header.Rows.Add(hrow);
            }
            foreach (var td in transactionDetails) {
                var drow = details.NewRow();
                drow["transaction_id"] = td.transactionId;
                drow["makeup_id"] = td.makeupId;
                drow["quantity"] = td.quantity;
                drow["item_price"] = td.Makeup.price;
                drow["sub_total"] = td.quantity * td.Makeup.price;
                details.Rows.Add(drow);
            }
            return data;
        }
    }
}