using AoL.Models;
using AoL.Repo;
using System;

namespace AoL.Masters {
    public partial class Nav : System.Web.UI.MasterPage {
        private readonly UserRepo _userRepo = new UserRepo();

        private void SaveSession(User user) {
            Session["User"] = user.username;
            Session["Role"] = user.role;
            Session["Id"] = user.id;
        }

        private void VerifyAuth() {
            var user = _userRepo.GetUser(Session["User"].ToString(), Session["Password"].ToString());
            if (user == null) {
                Session.Clear();
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            var cookieUsername = Request.Cookies["Username"];
            var cookiePassword = Request.Cookies["Password"];

            if (Session["User"] == null) {
                if (cookieUsername != null && cookiePassword != null) {
                    var user = _userRepo.GetUser(cookieUsername.Value, cookiePassword.Value);

                    if (user == null) { return; }

                    SaveSession(user);
                } else {
                    return;
                }
            } else {
                VerifyAuth();
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
            Session.Clear();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}