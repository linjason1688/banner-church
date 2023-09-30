using CaseExtensions;

namespace App.Utility.Extensions
{
    public static class StringExtension
    {
        public static string ToCamelCase(this string @this)
        {
            return StringExtensions.ToCamelCase(@this);
        }

        public static string ToPascalCase(this string @this)
        {
            return StringExtensions.ToPascalCase(@this);
        }
    }
}
