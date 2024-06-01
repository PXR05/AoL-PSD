using AoL.Models;
using AoL.Repo;
using System.Collections.Generic;

namespace AoL.Handlers {
    public static class TypeHandler {
        public static List<MakeupType> GetAllMakeupTypes() {
            return TypeRepo.GetAllMakeupTypes();
        }

        public static MakeupType GetType(int id) {
            return TypeRepo.GetType(id);
        }
    }
}