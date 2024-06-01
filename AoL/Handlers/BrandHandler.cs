using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Handlers
{
    public class BrandHandler
    {
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return BrandRepo.GetAllMakeupBrands();
        }

        public static MakeupBrand GetBrand(int id)
        {
            return BrandRepo.GetBrand(id);  
        }
    }
}