using AoL.Controllers;
using System;
using System.Web;

namespace AoL.Masters {
    public partial class Nav : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                return;
            }

            var error = "";
            if (Session["User"] == null) {
                error = AuthController.LoginUser(Response.Cookies["Username"]?.Value, Response.Cookies["Password"]?.Value);
            } else if (Session["Password"] != null) {
                error = AuthController.LoginUser(Session["User"].ToString(), Session["Password"].ToString());
            }

            if (error != "") {
                Session.Abandon();
                return;
            }

            if (HttpContext.Current.Request.Url.AbsolutePath == "/Views/Login.aspx" ||
                HttpContext.Current.Request.Url.AbsolutePath == "/Views/Register.aspx") {
                Response.Redirect("~/Views/Home.aspx");
            }

            All.Visible = true;

            switch (Session["Role"].ToString()) {
                case "admin":
                    Admin.Visible = true;
                    break;
                case "user":
                    User.Visible = true;
                    break;
            }
        }

        protected void Logout_Click(object sender, EventArgs e) {
            if (Request.Cookies["Username"] != null) {
                Request.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Request.Cookies["Password"] != null) {
                Request.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Clear();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}