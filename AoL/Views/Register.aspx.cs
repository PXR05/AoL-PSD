using AoL.Handlers;
using System;

namespace AoL.Views {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] != null) {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        private readonly UserHandler _userHandler = new UserHandler();

        protected void RegButton_OnClick(object sender, EventArgs e) {
            var username = Username.Text;
            var email = Email.Text;
            var password = Password.Text;
            var confPassword = ConfPassword.Text;
            var dob = DoB.Text;
            var gender = Gender.Text;

            var error = _userHandler.RegisterUser(username, email, password, confPassword, dob, gender);

            if (error != "") {
                Error.Text = error;
                return;
            }

            Response.Redirect("~/Views/Login.aspx");
        }
    }
}