using AoL.Handlers;
using AoL.Repo;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Controllers {
    public static class MakeupController {
        private static string ValidateName(string name) {
            return name.Length < 1 || name.Length > 99 ? "Name must be between 1-99 characters." : "";
        }

        private static string ValidateMakeupPrice(int price) {
            return price < 0 ? "Price must be greater than 0." : "";
        }

        private static string ValidateMakeupWeight(int weight) {
            return weight < 1 || weight > 1500 ? "Weight must be between 1-1500." : "";
        }

        private static string ValidateFilled(IEnumerable<string> items) {
            return items.Any(x => x == "") ? "Please fill in all fields." : "";
        }

        private static string ValidateRating(int rating) {
            return rating < 0 || rating > 100 ? "Rating must be between 0-100." : "";
        }

        private static string ValidateMakeup(string name, string price, string weight, int typeId, int brandId) {
            var error = ValidateFilled(new List<string> { name, price, weight });
            if (error != "") {
                return error;
            }

            if (typeId == -1 || brandId == -1) {
                return "Please fill in all fields.";
            }

            var priceInt = int.Parse(price ?? "-1");
            error = ValidateMakeupPrice(priceInt);
            if (error != "") {
                return error;
            }

            var weightInt = int.Parse(weight ?? "-1");
            error = ValidateMakeupWeight(weightInt);
            return error != "" ? error : "";
        }

        public static string AddMakeup(string name, string price, string weight, int typeId, int brandId) {
            var error = ValidateMakeup(name, price, weight, typeId, brandId);
            if (error != "") {
                return error;
            }

            var priceInt = int.Parse(price);
            var weightInt = int.Parse(weight);
            error = MakeupHandler.AddMakeup(name, priceInt, weightInt, typeId, brandId);
            return error;
        }

        public static string AddType(string name) {
            var error = ValidateName(name);
            return error != "" ? error : MakeupHandler.AddType(name);
        }

        public static string AddBrand(string name, int rating) {
            var error = ValidateName(name);
            if (error != "") {
                return error;
            }
            error = ValidateRating(rating);
            return error != "" ? error : MakeupHandler.AddBrand(name, rating);
        }

        public static string UpdateMakeup(int id, string name, string price, string weight, int typeId, int brandId) {
            var error = ValidateMakeup(name, price, weight, typeId, brandId);
            if (error != "") {
                return error;
            }

            var priceInt = int.Parse(price);
            var weightInt = int.Parse(weight);
            error = MakeupHandler.UpdateMakeup(id, name, priceInt, weightInt, typeId, brandId);

            return error;
        }

        public static string UpdateType(int id, string name) {
            var error = ValidateName(name);
            return error != "" ? error : MakeupHandler.UpdateType(id, name);
        }

        public static string UpdateBrand(int id, string name, int rating) {
            var error = ValidateName(name);
            if (error != "") {
                return error;
            }
            error = ValidateRating(rating);
            return error != "" ? error : MakeupHandler.UpdateBrand(id, name, rating);
        }

        public static string DeleteMakeup(int id) {
            return MakeupHandler.DeleteMakeup(id);
        }

        public static string DeleteType(int id) {
            var referenced = MakeupRepo.GetAllMakeups().Any(x => x.typeId == id);

            return referenced ? "Type is referenced by a makeup." : MakeupHandler.DeleteType(id);
        }

        public static string DeleteBrand(int id) {
            var referenced = MakeupRepo.GetAllMakeups().Any(x => x.brandId == id);

            return referenced ? "Brand is referenced by a makeup." : MakeupHandler.DeleteBrand(id);
        }
    }
}