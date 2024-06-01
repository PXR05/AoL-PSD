using AoL.Handlers;
using AoL.Models;
using System.Collections.Generic;

namespace AoL.Controllers {
    public static class BrandController {
        public static List<MakeupBrand> GetAllMakeupBrands() {
            return BrandHandler.GetAllMakeupBrands();
        }

        public static MakeupBrand GetBrand(int id) {
            return BrandHandler.GetBrand(id);
        }
    }
}