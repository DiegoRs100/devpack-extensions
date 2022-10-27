namespace Devpack.Extensions.Types
{
    public static class ExceptionExtensions
    {
        public static Dictionary<string, string> ToDictionary<TException>(this TException exception) where TException : Exception
        {
            var exceptionDictionary = new Dictionary<string, string>()
            {
                { "ExceptionType", typeof(TException).Name },
                { "ExceptionMessage", exception.Message }
            };

            if (exception?.InnerException?.Message != null)
                exceptionDictionary.Add("InnerExceptionMessage", exception.InnerException.Message);

            return exceptionDictionary;
        }
    }
}