using System;
using System.Linq;
using System.Reflection;

namespace App.Utility.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtension
    {
        public static T GetAttributeOf<T>(this Enum value)
            where T : Attribute
        {
            return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<T>();
        }
    }
}
