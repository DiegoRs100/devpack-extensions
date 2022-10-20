namespace Devpack.Extensions.Types
{
    public static class StreamExtensions
    {
        public static async Task<string> ReadToStringAsync(this Stream stream)
        {
            stream.Position = 0;

            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
}