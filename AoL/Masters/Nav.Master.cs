using AoL.Controllers;
using System;
using System.Web;

namespace AoL.Masters {
    public partial class Nav : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                return;
            }

            var isInAuthPage = HttpContext.Current.Request.Url.AbsolutePath == "/Views/Login.aspx" || HttpContext.Current.Request.Url.AbsolutePath == "/Views/Register.aspx";

            var sessionIsEmpty = Session["User"] == null || Session["Id"] == null;

            var cookieUsername = Request.Cookies["Username"]?.Value;
            var cookiePassword = Request.Cookies["Password"]?.Value;
            var cookieIsEmpty = cookieUsername == null || cookiePassword == null;

            if (sessionIsEmpty && cookieIsEmpty) {
                if (!isInAuthPage) {
                    Response.Redirect("~/Views/Login.aspx");
                }
                return;
            }

            var error = sessionIsEmpty
                ? AuthController.LoginUser(cookieUsername, cookiePassword)
                : AuthController.SessionLogin(Session["Id"].ToString());
            if (error != "") {
                return;
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

            if (isInAuthPage) {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void Logout_Click(object sender, EventArgs e) {
            if (Request.Cookies["Username"] != null) {
                var usernameCookie = new HttpCookie("Username") {
                    Expires = DateTime.Now.AddDays(-7)
                };
                Response.Cookies.Add(usernameCookie);
            }
            if (Request.Cookies["Password"] != null) {
                var passwordCookie = new HttpCookie("Password") {
                    Expires = DateTime.Now.AddDays(-7)
                };
                Response.Cookies.Add(passwordCookie);
            }

            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}