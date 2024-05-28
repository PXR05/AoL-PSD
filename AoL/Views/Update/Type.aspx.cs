using AoL.Controllers;
using AoL.Repo;
using System;

namespace AoL.Views.Update {
    public partial class Type : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (IsPostBack) {
                return;
            }

            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            if (id == -1) {
                Response.Redirect("~/Views/Manage.aspx");
            }

            var type = TypeRepo.GetType(id);
            if (type == null) {
                Response.Redirect("~/Views/Manage.aspx");
                return;
            }

            Name.Text = type.name;
        }

        protected void UpdateButton_OnClick(object sender, EventArgs e) {
            var name = Name.Text;

            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            var error = MakeupController.UpdateType(id, name);

            if (error != "") {
                ErrorLabel.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
    }
}