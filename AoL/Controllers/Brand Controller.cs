using AoL.Handlers;
using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Controllers
{
    public class BrandController
    {
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return BrandHandler.GetAllMakeupBrands();
        }

        public static MakeupBrand GetBrand(int id)
        {
            return BrandHandler.GetBrand(id);
        }
    }
}