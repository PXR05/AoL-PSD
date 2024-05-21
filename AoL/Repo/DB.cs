using AoL.Models;

namespace AoL.Repo {
    public static class Db {
        private static AoL_DBEntities _db;

        public static AoL_DBEntities Instance => _db ?? (_db = new AoL_DBEntities());
    }
}