using System;
using System.Globalization;

namespace Zadanie_rekrutacyjne_SellPander.Helpers
{
    internal static class ConvertToUnix
    {
        internal static long ConvertISOToUnix(string isoTime)
        {
            string dateTimeinISO8601 = isoTime;
            DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(dateTimeinISO8601, "yyyyMMdd'T'HHmmss.fff'Z'", CultureInfo.InvariantCulture);
            long unixTimeSeconds = dateTimeOffset.ToUnixTimeSeconds();

            return unixTimeSeconds;
        }
    }
}
