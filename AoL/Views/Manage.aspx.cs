using AoL.Controllers;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

namespace AoL.Views {
    public partial class Manage : System.Web.UI.Page {
        protected List<Makeup> Makeups = new List<Makeup>();
        protected List<MakeupBrand> Brands = new List<MakeupBrand>();
        protected List<MakeupType> Types = new List<MakeupType>();

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }

            Makeups = MakeupController.GetAllMakeups();
            Brands = BrandController.GetAllMakeupBrands();
            Types = TypeController.GetAllMakeupTypes();

            var action = Request.Params.Get("action");
            var item = Request.Params.Get("item");
            var id = int.Parse(Request.Params.Get("id") ?? "-1");

            if (action == null || item == null || action != "delete" || id == -1) return;

            switch (item) {
                case "makeup":
                    DeleteMakeup(id);
                    break;
                case "brand":
                    DeleteBrand(id);
                    break;
                case "type":
                    DeleteType(id);
                    break;
            }
        }

        private void DeleteMakeup(int id) {
            var error = MakeupController.DeleteMakeup(id);
            if (error != "") {
                MakeupError.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
        private void DeleteBrand(int id) {
            var error = MakeupController.DeleteBrand(id);
            if (error != "") {
                BrandError.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
        private void DeleteType(int id) {
            var error = MakeupController.DeleteType(id);
            if (error != "") {
                TypeError.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
    }
}