using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace RenergyInsights.Utillities
{
    public class UtilPractice
    {
        public static PropertyInfo GetPropertyInfo(string source, Type targetType)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException("Source string cannot be null or empty", nameof(source));

            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            // Convert to PascalCase
            string pascalCaseProperty = CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(source.Replace("_", " ").Replace("#", "").ToLower())
                .Replace(" ", "");

            // Get the property
            PropertyInfo property = targetType.GetProperty(pascalCaseProperty);

            if (property == null)
            {
                throw new ArgumentException(
                    $"Property '{pascalCaseProperty}' not found in type {targetType.Name}. " +
                    $"Source input was: '{source}'");
            }

            return property;
        }
    }

}

