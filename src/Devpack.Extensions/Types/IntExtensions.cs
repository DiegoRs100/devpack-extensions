namespace Devpack.Extensions.Types
{
    public static class IntExtensions
    {
        public static bool IsBetween(this int number, int startNumber, int endNumber)
        {
            return number >= startNumber && number <= endNumber;
        }
    }
}