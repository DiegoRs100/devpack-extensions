using System.Reflection;

namespace Devpack.Extensions.Types
{
    public static class ReflectionExtensions
    {
        public static TAttribute? GetAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
        {
            if (memberInfo.HasAttribute<TAttribute>())
                return memberInfo.GetCustomAttributes(typeof(TAttribute), false).First() as TAttribute;

            return null;
        }

        public static bool HasAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
        {
            return memberInfo.GetCustomAttributes(typeof(TAttribute), false).Length > 0;
        }
    }
}