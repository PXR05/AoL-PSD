using AoL.Models;
using AoL.Repo;
using System.Linq;

namespace AoL.Factories {
    public static class MakeupFactory {
        private static int NewId() {
            var maxId = MakeupRepo.GetAllMakeups();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static Makeup CreateMakeup(string name, int price, int weight, int typeId, int brandId) {
            return new Makeup {
                id = NewId(),
                name = name,
                price = price,
                weight = weight,
                typeId = typeId,
                brandId = brandId
            };
        }
    }
}