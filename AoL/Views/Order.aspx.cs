using AoL.Controllers;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Views {
    public partial class Order : System.Web.UI.Page {
        protected List<Makeup> Makeups = new List<Makeup>();
        protected List<Cart> Carts = new List<Cart>();
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (Session["Role"].ToString() != "user") {
                Response.Redirect("~/Views/Home.aspx");
            }

            Makeups = MakeupRepo.GetAllMakeups();
            Carts = CartRepo.GetAllCarts();

            var action = Request.Params.Get("action");
            if (action == "add") {
                AddToCart();
            }
        }

        private void AddToCart() {
            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            var quantity = int.Parse(Request.Params.Get("q") ?? "0");
            var error = OrderController.AddToCart(int.Parse(Session["Id"].ToString()), id, quantity);
            if (error == "") return;
            Error.Text = error;
        }
    }
}