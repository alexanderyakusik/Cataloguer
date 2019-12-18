using System;

namespace Cataloguer.UI.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToLocaleDate(this DateTime dateTime)
        {
            return dateTime.ToString("D", new System.Globalization.CultureInfo("ru-RU"));
        }
    }
}
