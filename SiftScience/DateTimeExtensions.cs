using System;

namespace SiftScience
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts datetime to Unix Timestamp (ISO 8601)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToUnixTime(this DateTime value)
        {
            if (value.Kind != DateTimeKind.Utc) value = value.ToUniversalTime();

            var seconds = (int)(value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

            return seconds;
        }
    }
}
