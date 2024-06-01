using AoL.Models;
using AoL.Repo;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class BrandHandler {
        public static List<MakeupBrand> GetAllMakeupBrands() {
            return BrandRepo.GetAllMakeupBrands();
        }

        public static MakeupBrand GetBrand(int id) {
            return BrandRepo.GetBrand(id);
        }
    }
}