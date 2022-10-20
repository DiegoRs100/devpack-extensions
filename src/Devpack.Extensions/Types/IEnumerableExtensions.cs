namespace Devpack.Extensions.Types
{
    public static class IEnumerableExtensions
    {
        private const int maxCountIsDuplicated = 1;

        public static bool IsNullOrEmpty<TClass>(this IEnumerable<TClass> list)
        {
            return list is null || !list.Any();
        }

        public static IEnumerable<TClass?> Distinct<TClass>(this IEnumerable<TClass> list, Func<TClass, object> key)
        {
            return list.GroupBy(key).Select(g => g.FirstOrDefault());
        }

        public static bool ContainsAny<TClass>(this IEnumerable<TClass> list, params TClass[] values)
        {
            return list.Intersect(values).Any();
        }

        public static IEnumerable<TClass> DistinctByMaxValue<TClass, TKey, TValue>(this IEnumerable<TClass> list,
            Func<TClass, TKey> key,
            Func<TClass, TValue> fieldToCompare)
        {
            return list.GroupBy(key).Select(gl => gl.OrderByDescending(fieldToCompare).First());
        }

        public static bool IsDuplicated<TClass, TKey>(this IEnumerable<TClass> list, Func<TClass, TKey> groupBy)
        {
            return list.GroupBy(groupBy).Any(g => g.Count() > maxCountIsDuplicated);
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var i in enumerable)
                action(i);
            return enumerable;
        }
    }
}