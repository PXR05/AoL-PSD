using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public class MakeupRepo {
        private readonly AoL_DBEntities _db = Db.Instance;

        public Makeup GetMakeup(int id) {
            return (from m in _db.Makeups
                    where m.id == id
                    select m).FirstOrDefault();
        }

        public List<Makeup> GetAllMakeups() {
            return (from m in _db.Makeups
                    select m).ToList();
        }
    }
}