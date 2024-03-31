namespace Devpack.Extensions.Types
{
    public static class StreamExtensions
    {
        public static async Task<string> ReadAsStringAsync(this Stream stream)
        {
            stream.Position = 0;

            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        public static MemoryStream ToMemoryStream(this object obj)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write(obj);
            writer.Flush();

            stream.Position = 0;

            return stream;
        }
    }
}