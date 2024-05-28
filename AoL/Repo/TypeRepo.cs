using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class TypeRepo {
        public static List<MakeupType> GetAllMakeupTypes() {
            return (from t in Db.Instance.MakeupTypes
                    select t).ToList();
        }

        public static MakeupType GetType(int id) {
            return (from t in Db.Instance.MakeupTypes
                    where t.id == id
                    select t).FirstOrDefault();
        }

        public static string DeleteType(int id) {
            var type = (from t in Db.Instance.MakeupTypes
                        where t.id == id
                        select t).FirstOrDefault();

            if (type == null) {
                return "Type not found.";
            }

            Db.Instance.MakeupTypes.Remove(type);
            Db.Instance.SaveChanges();
            return "";
        }

        public static void AddType(MakeupType type) {
            Db.Instance.MakeupTypes.Add(type);
            Db.Instance.SaveChanges();
        }

        public static string UpdateType(int id, string name) {
            var type = (from t in Db.Instance.MakeupTypes
                        where t.id == id
                        select t).FirstOrDefault();

            if (type == null) {
                return "Type not found.";
            }

            type.name = name;
            Db.Instance.SaveChanges();
            return "";
        }
    }
}