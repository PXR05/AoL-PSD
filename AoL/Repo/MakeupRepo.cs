using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class MakeupRepo {

        public static Makeup GetMakeup(int id) {
            return Db.Instance.Makeups.FirstOrDefault((m) => m.id.Equals(id));
        }

        public static List<Makeup> GetAllMakeups() {
            return (from m in Db.Instance.Makeups
                    select m).ToList();
        }

        public static void AddMakeup(Makeup makeup) {
            Db.Instance.Makeups.Add(makeup);
            Db.Instance.SaveChanges();
        }

        public static string DeleteMakeup(int id) {
            var makeup = (from m in Db.Instance.Makeups
                          where m.id.Equals(id)
                          select m).FirstOrDefault();

            if (makeup == null) {
                return "Makeup not found!";
            }

            Db.Instance.Makeups.Remove(makeup);
            Db.Instance.SaveChanges();

            return "";
        }

        public static string UpdateMakeup(int id, string name, int price, int weight, int typeId, int brandId) {
            var makeup = (from m in Db.Instance.Makeups
                          where m.id.Equals(id)
                          select m).FirstOrDefault();

            if (makeup == null) {
                return "Makeup not found!";
            }

            makeup.name = name;
            makeup.price = price;
            makeup.weight = weight;
            makeup.typeId = typeId;
            makeup.brandId = brandId;
            Db.Instance.SaveChanges();

            return "";
        }
    }
}