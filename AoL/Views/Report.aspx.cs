using AoL.Controllers;
using AoL.DataSet;
using AoL.Models;
using AoL.Reportt;
using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoL.Views
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["Role"].ToString() != "admin")
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = GetData(TransactionHeaderController.GetAllTransactionHeaders(), TransactionDetailController.GetAllTransactionDetails());
            report.SetDataSource(data);

        }
        private DataSet1 GetData(List<TransactionHeader> transactionHeaders, List<TransactionDetail> transactionDetails)
        {
            DataSet1 data = new DataSet1();
            var header = data.transactions;
            var details = data.transactions_details;
            foreach (TransactionHeader th in transactionHeaders)
            {
                var hrow = header.NewRow();
                hrow["transaction_id"] = th.id;
                hrow["user_id"] = th.userId;
                //hrow["trasanction_date"] = th.transactionDate;
                hrow["status"] = th.status;
                header.Rows.Add(hrow);
            }
            foreach (TransactionDetail td in transactionDetails)
            {
                var drow = details.NewRow();
                drow["transaction_id"] = td.transactionId;
                drow["makeup_id"] = td.makeupId;
                drow["quantity"] = td.quantity;
                details.Rows.Add(drow);
            }
            return data;
            }
        }
}