using System.ComponentModel;

namespace Devpack.Extensions.Types
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumerator)
        {
            var type = enumerator.GetType();
            var memberInfo = type.GetMember(Enum.GetName(type, enumerator)!).First();
            var attribute = memberInfo.GetAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : memberInfo.Name;
        }
    }
}