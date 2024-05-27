using AoL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AoL.Repo {
    public static class TypeRepo {
        public static List<MakeupType> GetAllMakeupTypes() {
            return (from t in Db.Instance.MakeupTypes
                    select t).ToList();
        }
    }
}