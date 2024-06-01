using AoL.Controllers;
using AoL.Repo;
using System;
using System.Web;

namespace AoL.Views {
    public partial class Profile : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (IsPostBack) return;

            var user = UserController.GetUser(int.Parse(Session["Id"].ToString()));
            if (user == null) {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }
            UpdateFields(user.id, user.username, user.email, user.dob.ToString("yyyy-MM-dd"), user.gender);
        }

        private void UpdateFields(int id, string username, string email, string dob, string gender) {
            UserId.Text = id.ToString();
            Username.Text = username;
            Email.Text = email;
            DoB.Text = dob;
            Gender.Text = gender;
        }

        private void AddToCookie(string key, string value) {
            var cookie = new HttpCookie(key, value);
            Response.Cookies.Add(cookie);
        }

        protected void UpdateButton_OnClick(object sender, EventArgs e) {
            var id = int.Parse(UserId.Text);
            var username = Username.Text;
            var email = Email.Text;
            var dob = DoB.Text;
            var gender = Gender.Text;

            var error = AuthController.UpdateUser(id, username, email, gender, dob);
            if (error != "") {
                Error.Text = error;
                return;
            }

            Error.Text = "Profile updated!";

            AddToCookie("Username", username);

            UpdateFields(id, username, email, dob, gender);
        }

        protected void Change_OnClick(object sender, EventArgs e) {
            var id = int.Parse(UserId.Text);
            var oldPassword = OldPass.Text;
            var newPassword = NewPass.Text;
            var error = AuthController.UpdatePassword(id, oldPassword, newPassword);
            if (error != "") {
                PassError.Text = error;
                return;
            }
            PassError.Text = "Password updated!";
        }
    }
}