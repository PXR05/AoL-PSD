using AoL.Controllers;
using AoL.Repo;
using System;

namespace AoL.Views.Add {
    public partial class Makeup : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }

            TypeList.DataSource = TypeController.GetAllMakeupTypes();
            TypeList.DataTextField = "name";
            TypeList.DataValueField = "id";
            TypeList.DataBind();
            BrandList.DataSource = BrandController.GetAllMakeupBrands();
            BrandList.DataTextField = "name";
            BrandList.DataValueField = "id";
            BrandList.DataBind();
        }

        protected void AddButton_OnClick(object sender, EventArgs e) {
            var name = Name.Text;
            var price = Price.Text;
            var weight = Weight.Text;
            var typeId = int.Parse(TypeList.SelectedValue);
            var brandId = int.Parse(BrandList.SelectedValue);

            var error = MakeupController.AddMakeup(name, price, weight, typeId, brandId);

            if (error != "") {
                Error.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
    }
}