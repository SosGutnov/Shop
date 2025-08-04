using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Shop.Helpers
{
    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
