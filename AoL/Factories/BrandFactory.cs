using AoL.Models;
using AoL.Repo;
using System.Linq;

namespace AoL.Factories {
    public static class BrandFactory {
        private static int NewId() {
            var maxId = BrandRepo.GetAllMakeupBrands();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static MakeupBrand CreateBrand(string name, int rating) {
            return new MakeupBrand {
                id = NewId(),
                name = name, 
                rating = rating
            };
        }
    }
}