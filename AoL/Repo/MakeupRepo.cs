using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class MakeupRepo {
        private static readonly AoL_DBEntities Db = Repo.Db.Instance;

        public static Makeup GetMakeup(int id) {
            return (from m in Db.Makeups
                    where m.id == id
                    select m).FirstOrDefault();
        }

        public static List<Makeup> GetAllMakeups() {
            return (from m in Db.Makeups
                    select m).ToList();
        }
    }
}