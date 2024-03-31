using System.Text.Json;
using System.Text;

namespace Devpack.Extensions.Helpers
{
    public static class HttpClientHelper
    {
        public static StringContent ParseToStringContent(object obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}