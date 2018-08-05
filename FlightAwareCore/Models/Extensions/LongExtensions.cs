using System;

namespace FlightAware.Models
{
    public static class LongExtensions
    {
        public static DateTimeOffset ToDateTimeOffsetFromUnixTimestamp(this long time)
        {
            return DateTimeOffset.FromUnixTimeSeconds(time);
        }
    }
}