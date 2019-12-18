using System;
using System.Text;

namespace Cataloguer.UI.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToShortForm(this TimeSpan timeSpan)
        {
            var stringBuilder = new StringBuilder();

            bool hasMinutes = timeSpan.Minutes > 0;

            if (timeSpan.Hours > 0)
            {
                stringBuilder.Append(string.Format($"{timeSpan.Hours}ч"));

                if (hasMinutes)
                {
                    stringBuilder.Append(" ");
                }
            }

            if (hasMinutes)
            {
                stringBuilder.Append($"{timeSpan.Minutes}мин");
            }

            string result = stringBuilder.ToString();

            return string.IsNullOrEmpty(result)
                ? "Не указана"
                : result;
        }
    }
}
