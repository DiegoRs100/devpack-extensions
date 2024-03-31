using TimeZoneConverter;

namespace Devpack.Extensions.Types
{
    public static class DateTimeExtensions
    {
        public const string SouthAmericaStandardTime = "America/Sao_Paulo";

        public static DateTime ConvertTimeToSouthAmericaZone(this DateTime dateTime)
        {
            return dateTime.ConvertTimeZone(SouthAmericaStandardTime);
        }

        private static DateTime ConvertTimeZone(this DateTime dateTime, string timeZoneId)
        {
            var timeZone = TZConvert.GetTimeZoneInfo(timeZoneId);
            return TimeZoneInfo.ConvertTime(dateTime, timeZone);
        }

        public static string ToOffsetString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss");
        }
    }
}