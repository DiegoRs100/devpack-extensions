using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Devpack.Extensions.Tests.Common
{
    public static class ReflectionExtensions
    {
        public static TObject SetPropertyValue<TObject, TReturn>(this TObject obj, Expression<Func<TObject, TReturn>> property,
            TReturn value)
        {
            var propertyInfo = obj.GetPropertyInfo(property);
            propertyInfo?.SetValue(obj, value);

            return obj;
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
    }
}