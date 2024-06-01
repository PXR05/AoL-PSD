using AoL.Controllers;
using AoL.Repo;
using System;

namespace AoL.Views.Update {
    public partial class Makeup : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["User"] == null || Session["Role"].ToString() != "admin") {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (IsPostBack) {
                return;
            }

            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            if (id == -1) {
                Response.Redirect("~/Views/Manage.aspx");
            }

            var makeup = MakeupController.GetMakeup(id);
            if (makeup == null) {
                Response.Redirect("~/Views/Manage.aspx");
                return;
            }

            Name.Text = makeup.name;
            Price.Text = makeup.price.ToString();
            Weight.Text = makeup.weight.ToString();

            TypeList.DataSource = TypeController.GetAllMakeupTypes();
            TypeList.DataTextField = "name";
            TypeList.DataValueField = "id";
            TypeList.DataBind();
            TypeList.SelectedValue = makeup.typeId.ToString();
            TypeList.DataBind();
            BrandList.DataSource = BrandController.GetAllMakeupBrands();
            BrandList.DataTextField = "name";
            BrandList.DataValueField = "id";
            BrandList.DataBind();
            BrandList.SelectedValue = makeup.brandId.ToString();
            BrandList.DataBind();
        }

        protected void UpdateButton_OnClick(object sender, EventArgs e) {
            var name = Name.Text;
            var price = Price.Text;
            var weight = Weight.Text;
            var typeId = int.Parse(TypeList.SelectedValue);
            var brandId = int.Parse(BrandList.SelectedValue);

            var id = int.Parse(Request.Params.Get("id") ?? "-1");
            var error = MakeupController.UpdateMakeup(id, name, price, weight, typeId, brandId);

            if (error != "") {
                ErrorLabel.Text = error;
                return;
            }

            Response.Redirect("~/Views/Manage.aspx");
        }
    }
}