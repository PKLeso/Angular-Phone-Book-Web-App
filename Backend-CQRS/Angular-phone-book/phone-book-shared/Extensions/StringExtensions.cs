
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace phone_book_shared.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

        public static string ToLowerCamelCase(this string str)
        {
            string[] split = Regex.Split(str, @"(?<!^)(?=[A-Z])");
            string output = "";
            string stringValue = "";

            for (int i = 0; i < split.Length; i++)
            {
                if (i == 0)
                    stringValue = split[i];

                else
                    stringValue += " " + split[i];
            }

            ;
            if (String.IsNullOrEmpty(str) == false)
            {
                output = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(stringValue);
                output = output.Replace(" ", "");
                if (String.IsNullOrEmpty(output) == false)
                {
                    output = char.ToLower(output[0]) + output.Substring(1);
                }
            }
            return output;
        }
    }
}
