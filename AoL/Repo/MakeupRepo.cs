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
    }
}