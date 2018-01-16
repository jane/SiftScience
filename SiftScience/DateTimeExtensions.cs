using System;

namespace SiftScience
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts DateTime to Unix Timestamp (ISO 8601)
        /// </summary>
        public static long ToUnixTimestamp(this DateTime date)
        {
            return new DateTimeOffset(date).ToUnixTimeSeconds();
        }
    }
}
