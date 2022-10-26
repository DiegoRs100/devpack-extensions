using System.Linq.Expressions;
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

        private static readonly BindingFlags PrivateBindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        public static object? GetPropertyValue<TCLass>(this TCLass obj, string propertyName) where TCLass : class
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName, PrivateBindFlags);

            if (propertyInfo == null)
                throw new InvalidOperationException("The property provided does not exist.");

            return propertyInfo.GetValue(obj);
        }

        public static TCLass SetPropertyValue<TCLass, TReturn>(this TCLass obj, Expression<Func<TCLass, TReturn>> property, TReturn value)
             where TCLass : class
        {
            var propertyInfo = obj.GetPropertyInfo(property);
            propertyInfo?.SetValue(obj, value);

            return obj;
        }

        public static object? GetFieldValue<TCLass>(this TCLass obj, string fieldName) where TCLass : class
        {
            var fieldInfo = obj.GetFildInfo(fieldName);
            return fieldInfo.GetValue(obj);
        }

        public static void SetFieldValue<TCLass>(this TCLass obj, string fieldName, object value) where TCLass : class
        {
            var fieldInfo = obj.GetFildInfo(fieldName);
            fieldInfo.SetValue(obj, value);
        }

        private static MemberInfo? GetMember<TObject, TReturn>(this TObject _, Expression<Func<TObject, TReturn>> selector)
        {
            if (selector.Body is MemberExpression memberExpression)
                return memberExpression.Member;

            return null;
        }

        private static PropertyInfo? GetPropertyInfo<TObject, TReturn>(this TObject obj, Expression<Func<TObject, TReturn>> property)
        {
            return obj.GetMember(property) as PropertyInfo;
        }

        private static FieldInfo GetFildInfo<TCLass>(this TCLass obj, string fieldName) where TCLass : class
        {
            var fieldInfo = obj.GetType().GetField(fieldName, PrivateBindFlags);

            if (fieldInfo == null)
                throw new InvalidOperationException("The field provided does not exist.");

            return fieldInfo;
        }
    }
}