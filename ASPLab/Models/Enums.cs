using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ASPLab_P.Models
{
    public static class Enums
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayName = enumValue.GetType()
                                       .GetMember(enumValue.ToString())
                                       .FirstOrDefault()?
                                       .GetCustomAttribute<DisplayAttribute>()?
                                       .GetName();

            return displayName ?? enumValue.ToString();
        }
    }
}
