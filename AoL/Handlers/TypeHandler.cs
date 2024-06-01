using AoL.Models;
using AoL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoL.Handlers
{
    public class TypeHandler
    {
        public static List<MakeupType> GetAllMakeupTypes()
        {
            return TypeRepo.GetAllMakeupTypes();
        }

        public static MakeupType GetType(int id)
        {
            return TypeRepo.GetType(id);
        }
    }
}