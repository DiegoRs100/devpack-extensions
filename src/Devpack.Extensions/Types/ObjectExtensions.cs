using System.Text.Encodings.Web;
using System.Text.Json;

namespace Devpack.Extensions.Types
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
        {
            return value == DBNull.Value || value == null;
        }

        public static bool In<TEntity>(this TEntity obj, params TEntity[] values)
        {
            return values.Contains(obj);
        }

        public static bool NotIn<TEntity>(this TEntity obj, params TEntity[] values)
        {
            return !values.Contains(obj);
        }

        public static string ToJson<TEntity>(this TEntity obj)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(obj, options);
        }
    }
}