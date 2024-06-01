using AoL.Factories;
using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;

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

        public static List<Makeup> GetAllMakeups()
        {
            return MakeupRepo.GetAllMakeups();
        }

        public static Makeup GetMakeup(int id)
        {
            return MakeupRepo.GetMakeup(id);
        }

        public static string AddType(string name) {
            var type = TypeFactory.CreateType(name);
            try {
                TypeRepo.AddType(type);
            } catch (Exception e) {
                return e.Message;
            }

            return "";
        }

        public static string AddBrand(string name, int rating) {
            var brand = BrandFactory.CreateBrand(name, rating);
            try {
                BrandRepo.AddBrand(brand);
            } catch (Exception e) {
                return e.Message;
            }

            return "";
        }

        public static string UpdateMakeup(int id, string name, int price, int weight, int typeId, int brandId) {
            return MakeupRepo.UpdateMakeup(id, name, price, weight, typeId, brandId);
        }

        public static string UpdateType(int id, string name) {
            return TypeRepo.UpdateType(id, name);
        }

        public static string UpdateBrand(int id, string name, int rating) {
            return BrandRepo.UpdateBrand(id, name, rating);
        }

        public static string DeleteMakeup(int id) {
            return MakeupRepo.DeleteMakeup(id);
        }

        public static string DeleteType(int id) {
            return TypeRepo.DeleteType(id);
        }

        public static string DeleteBrand(int id) {
            return BrandRepo.DeleteBrand(id);
        }
    }
}