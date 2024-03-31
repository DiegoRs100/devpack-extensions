using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Devpack.Extensions.Types
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumerator)
        {
            var type = enumerator.GetType();
            var memberInfo = type.GetMember(Enum.GetName(type, enumerator)!)[0];
            var attribute = memberInfo.GetAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : memberInfo.Name;
        }

        public static string GetDisplayName(this Enum enumerator)
        {
            var type = enumerator.GetType();
            var memberInfo = type.GetMember(Enum.GetName(type, enumerator)!)[0];
            var attribute = memberInfo.GetAttribute<DisplayAttribute>();

            return attribute?.Name ?? memberInfo.Name;
        }

        public static string ToNumberString(this Enum enumerator)
        {
            return Convert.ToInt32(enumerator).ToString();
        }
    }
}