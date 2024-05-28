using AoL.Models;
using AoL.Repo;
using System.Linq;

namespace AoL.Factories {
    public static class TypeFactory {
        private static int NewId() {
            var maxId = TypeRepo.GetAllMakeupTypes();
            return maxId.Count == 0 ? 1 : maxId.Max(x => x.id) + 1;
        }

        public static MakeupType CreateType(string name) {
            return new MakeupType {
                id = NewId(),
                name = name
            };
        }
    }
}