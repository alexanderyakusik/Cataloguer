using System;
using System.Text;

namespace Cataloguer.UI.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToShortForm(this TimeSpan timeSpan)
        {
            var stringBuilder = new StringBuilder();
            if (timeSpan.Hours > 0)
            {
                stringBuilder.Append(string.Format($"{timeSpan.Hours}ч"));
            }
            if (timeSpan.Minutes > 0)
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
