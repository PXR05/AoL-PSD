using AoL.Controllers;
using AoL.Models;
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

            Makeups = MakeupController.GetAllMakeups();
            Makeups.Sort((b, a) => a.MakeupBrand.rating - b.MakeupBrand.rating);
            Carts = CartController.GetAllCarts();
            Carts.Reverse();

            var action = Request.Params.Get("action");
            switch (action) {
                case "add":
                    AddToCart();
                    break;
                case "clear":
                    ClearCart();
                    break;
                case "checkout":
                    Checkout();
                    break;
            }
        }

        private void Checkout() {
            var userId = int.Parse(Session["Id"].ToString());
            var error = OrderController.Checkout(userId, Carts);
            if (error == "") {
                ClearCart();
            }
            Error.Text = error;
        }

        private void ClearCart() {
            var userId = int.Parse(Session["Id"].ToString());
            var error = OrderController.ClearCart(userId);
            if (error == "") {
                Response.Redirect("~/Views/Order.aspx", true);
            }
            Error.Text = error;
        }

        private void AddToCart() {
            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            var quantity = int.Parse(Request.Params.Get("q") ?? "0");
            var error = OrderController.AddToCart(int.Parse(Session["Id"].ToString()), id, quantity);
            if (error == "") {
                Response.Redirect("~/Views/Order.aspx");
            }
            Error.Text = error;
        }
    }
}