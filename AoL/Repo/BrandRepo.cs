using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class BrandRepo {
        public static List<MakeupBrand> GetAllMakeupBrands() {
            return (from b in Db.Instance.MakeupBrands
                    select b).ToList();
        }
    }
}