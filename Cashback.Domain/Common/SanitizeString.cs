namespace Cashback.Domain.Common
{
    public static class SanitizeString
    {
        public static string Sanitize(this string str, string charsToRemove)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                var result = str;

                foreach (var character in charsToRemove)
                {
                    result = result.Replace(character.ToString(), string.Empty);
                }
                return result;
            }
            return string.Empty;
        }
    }
}
