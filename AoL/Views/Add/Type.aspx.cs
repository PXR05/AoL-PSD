using AoL.Controllers;
using System;

namespace AoL.Views.Add {
    public partial class Type : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void AddButton_OnClick(object sender, EventArgs e) {
            var name = Name.Text;
            var error = MakeupController.AddType(name);
            if (error != "") {
                Error.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
    }
}