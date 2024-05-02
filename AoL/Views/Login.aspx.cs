﻿using AoL.Handlers;
using AoL.Models;
using System;
using System.Web;

namespace AoL.Views {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] != null) {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        private void AddToCookie(string key, string value) {
            var cookie = new HttpCookie(key, value);
            Response.Cookies.Add(cookie);
        }

        private readonly UserHandler _userHandler = new UserHandler();

        private void SaveSession(User user) {
            Session["User"] = user.username;
            Session["Role"] = user.role;
            Session["Id"] = user.id;
        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            var username = Username.Text;
            var password = Password.Text;

            var (error, user) = _userHandler.LoginUser(username, password);
            if (error != "") {
                Error.Text = error;
                return;
            }

            if (Remember.Checked) {
                AddToCookie("Username", username);
                AddToCookie("Password", password);
            }

            SaveSession(user);

            Response.Redirect("~/Views/Home.aspx");
        }
    }
}