using AoL.Handlers;
using AoL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Controllers
{
    public class TypeController
    {
        public static List<MakeupType> GetAllMakeupTypes()
        {
            return TypeHandler.GetAllMakeupTypes();
        }

        public static MakeupType GetType(int id)
        {
            return TypeHandler.GetType(id); 
        }
    }
}