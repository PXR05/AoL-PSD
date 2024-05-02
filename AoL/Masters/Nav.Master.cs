using AoL.Repo;
using System;

namespace AoL.Masters {
    public partial class Nav : System.Web.UI.MasterPage {
        private readonly UserRepo _userRepo = new UserRepo();

        protected void Page_Load(object sender, EventArgs e) {
            var cookieUsername = Request.Cookies["Username"];
            var cookiePassword = Request.Cookies["Password"];

            if (Session["User"] == null && cookieUsername == null) { return; }

            if (Session["User"] == null) {
                if (cookieUsername == null || cookiePassword == null) { return; }

                var user = _userRepo.GetUser(cookieUsername.ToString(), cookiePassword.ToString());

                if (user == null) { return; }

                Session["User"] = user.username;
                Session["Role"] = user.role;
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