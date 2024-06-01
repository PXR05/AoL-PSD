using AoL.Handlers;
using AoL.Models;
using System.Collections.Generic;

namespace AoL.Controllers {
    public static class TypeController {
        public static List<MakeupType> GetAllMakeupTypes() {
            return TypeHandler.GetAllMakeupTypes();
        }

        public static MakeupType GetType(int id) {
            return TypeHandler.GetType(id);
        }
    }
}