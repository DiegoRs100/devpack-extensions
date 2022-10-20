using Devpack.Extensions.Types;

namespace Devpack.Extensions.Helpers
{
    public static class StringHelper
    {
        public static bool HasValueInAny(params string[] values)
        {
            foreach (var value in values)
            {
                if (!value.IsNullOrEmpty())
                    return true;
            }

            return false;
        }
    }
}