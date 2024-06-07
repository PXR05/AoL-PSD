using AoL.Models;

namespace AoL.Repo {
    public static class Db {
        private static AoL_DBEntities1 _db;

        public static AoL_DBEntities1 Instance => _db ?? (_db = new AoL_DBEntities1());
    }
}