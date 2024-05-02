using AoL.Handlers;
using AoL.Models;
using AoL.Repo;
using System;

namespace AoL.Views {
    public partial class Profile : System.Web.UI.Page {
        private readonly UserHandler _userHandler = new UserHandler();
        private readonly UserRepo _userRepo = new UserRepo();

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (IsPostBack) return;

            var user = _userRepo.GetUser(int.Parse(Session["Id"].ToString()));
            if (user == null) {
                Response.Redirect("~/Views/Login.aspx");
            }
            UpdateFields(user);
        }

        private void UpdateFields(User user) {
            UserId.Text = user.id.ToString();
            Username.Text = user.username;
            Email.Text = user.email;
            DoB.Text = user.dob.ToString("yyyy-MM-dd");
            Gender.Text = user.gender;
        }

        protected void UpdateButton_OnClick(object sender, EventArgs e) {
            var id = int.Parse(UserId.Text);
            var username = Username.Text;
            var email = Email.Text;
            var dob = DoB.Text;
            var gender = Gender.Text;

            var (error, user) = _userHandler.UpdateUser(id, username, email, gender, dob);
            if (error != "") {
                Error.Text = error;
                return;
            }

            if (user == null) { return; }

            Error.Text = "Profile updated!";

            UpdateFields(user);
        }
    }
}