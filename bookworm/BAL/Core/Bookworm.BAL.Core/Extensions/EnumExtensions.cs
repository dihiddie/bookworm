using System;
using System.Linq;

namespace Bookworm.BAL.Core.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var name = Enum.GetName(type, enumValue);
            return type.GetField(name).GetCustomAttributes(false).OfType<T>().SingleOrDefault();
        }

    }
}
