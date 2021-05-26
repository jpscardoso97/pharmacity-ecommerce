namespace Crosscutting.Helpers
{
    using System;

    public static class DateHelper
    {
        public static string GenerateReadableDateTime(DateTime date = default) =>
            date != default
                ? $"{date.ToShortDateString()}-{date.ToShortTimeString()}"
                : $"{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToShortTimeString()}";
    }
}