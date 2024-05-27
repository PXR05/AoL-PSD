using AoL.Factories;
using AoL.Repo;
using System;

namespace AoL.Handlers {
    public static class MakeupHandler {
        public static string AddMakeup(string name, int price, int weight, int typeId, int brandId) {
            var makeup = MakeupFactory.CreateMakeup(name, price, weight, typeId, brandId);
            try {
                MakeupRepo.AddMakeup(makeup);
            } catch (Exception e) {
                return e.Message;
            }

            return "";
        }

        public static string UpdateMakeup(int id, string name, int price, int weight, int typeId, int brandId) {
            return MakeupRepo.UpdateMakeup(id, name, price, weight, typeId, brandId);
        }

        public static string DeleteMakeup(int id) {
            return MakeupRepo.DeleteMakeup(id);
        }
    }
}