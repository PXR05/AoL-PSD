using AoL.Handlers;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Views {
    public partial class Order : System.Web.UI.Page {
        private readonly MakeupRepo _makeupRepo = new MakeupRepo();
        protected List<Makeup> Makeups = new List<Makeup>();
        protected List<Cart> Carts = new List<Cart>();
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null) {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (Session["Role"].ToString() != "user") {
                Response.Redirect("~/Views/Home.aspx");
            }

            Makeups = _makeupRepo.GetAllMakeups();

            var action = Request.Params.Get("action");
            if (action == "add") {
                AddToCart();
            }
        }

        private readonly CartHandler _cartHandler = new CartHandler();
        private void AddToCart() {
            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            var quantity = int.Parse(Request.Params.Get("q") ?? "0");
            var (error, cart) = _cartHandler.AddToCart(int.Parse(Session["Id"].ToString()), id, quantity);
            if (error != "") {
                Error.Text = error;
                return;
            }
            Carts.Add(cart);
        }
    }
}