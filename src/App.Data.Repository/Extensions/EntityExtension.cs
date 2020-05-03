using App.Data.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repository.Extensions
{
    public static class EntityExtension
    {
        public static bool IsNotNull(this Entity entity)
        {
            return entity != null;
        }

        public static bool IsNull(this Entity entity)
        {
            return entity is null;
        }
    }
}
