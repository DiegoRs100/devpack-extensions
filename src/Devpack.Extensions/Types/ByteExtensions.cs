namespace Devpack.Extensions.Types
{
    public static class ByteExtensions
    {
        public static string ToHexadecimal(this byte[] bytes)
        {
            return string.Join(string.Empty, bytes.Select(b => b.ToString("x2")));
        }
    }
}