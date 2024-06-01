using AoL.Controllers;
using AoL.Repo;
using System;

namespace AoL.Views {
    public partial class Home : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (Session["Role"].ToString() == "admin") {
                UserList.DataSource = UserController.GetAllUsers();
                UserList.DataBind();
            } else {
                UserList.Visible = false;
            }

            CurrUser.InnerHtml = Session["User"] + " <br> <small style='font-size: 1rem; font-weight: 400'>Role: " + Session["Role"] + "</small>";
        }
    }
}