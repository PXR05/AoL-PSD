using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class BrandRepo {
        public static List<MakeupBrand> GetAllMakeupBrands() {
            return (from b in Db.Instance.MakeupBrands
                    select b).ToList();
        }

        public static MakeupBrand GetBrand(int id) {
            return (from b in Db.Instance.MakeupBrands
                    where b.id == id
                    select b).FirstOrDefault();
        }

        public static void AddBrand(MakeupBrand brand) {
            Db.Instance.MakeupBrands.Add(brand);
            Db.Instance.SaveChanges();
        }

        public static string DeleteBrand(int id) {
            var brand = (from b in Db.Instance.MakeupBrands
                         where b.id == id
                         select b).FirstOrDefault();

            if (brand == null) {
                return "Brand not found.";
            }

            Db.Instance.MakeupBrands.Remove(brand);
            Db.Instance.SaveChanges();
            return "";
        }

        public static string UpdateBrand(int id, string name, int rating) {
            var brand = (from b in Db.Instance.MakeupBrands
                         where b.id == id
                         select b).FirstOrDefault();

            if (brand == null) {
                return "Brand not found.";
            }

            brand.name = name;
            brand.rating = rating;
            Db.Instance.SaveChanges();
            return "";
        }
    }
}