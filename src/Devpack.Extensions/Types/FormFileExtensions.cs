using Microsoft.AspNetCore.Http;

namespace Devpack.Extensions.Types
{
    public static class FormFileExtensions
    {
        public static string ToBase64(this IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}