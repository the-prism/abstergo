namespace Abstergo.Blazor
{
    using System.Reflection;
    using Microsoft.AspNetCore.Razor.Language;

    public class EnumValue : Attribute
    {
        public string Value { get; private set; }

        public EnumValue(string value)
        {
            this.Value = value;
        }
    }

    public class EnumCharSet : Attribute
    {
        public char Value { get; private set; }

        public EnumCharSet(char value)
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// Extensions for enum value to string
    /// </summary>
    public static class ExtensionMethods
    {
        public static string GetStringValue(this Enum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo? fieldInfo = type.GetField(stringValue);
            var attrs = fieldInfo?.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];
            if (attrs?.Length > 0)
            {
                stringValue = attrs[0].Value;
            }

            return stringValue;
        }

        public static char GetIconCharset(this Enum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo? fieldInfo = type.GetField(stringValue);
            var attrs = fieldInfo?.GetCustomAttributes(typeof(EnumCharSet), false) as EnumCharSet[];
            char result = '?';
            if (attrs?.Length > 0)
            {
                result = attrs[0].Value;
            }

            return result;
        }
    }
}
