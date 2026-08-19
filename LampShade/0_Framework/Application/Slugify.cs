using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _0_Framework.Application
{
    public static class Slugify
    {
        public static string GenerateSlug(this string phrase)
        {
            var s = phrase.RemoveDiacritics().ToLower();
            s = Regex.Replace(s, @"[^\u0600 - \u06FF\uFB8A")
        }

        public static string RemoveDiacritics(this string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                    return string.Empty;

            var normilizedString = text.Normalize(NormalizationForm.FormKC);
            var stringBuilder = new StringBuilder();

            foreach (var c in normilizedString)
            {
                var uniCodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uniCodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormKC);

        }
    }
}
