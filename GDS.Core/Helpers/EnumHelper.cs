using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GDS.Core.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T value) where T : IConvertible
        {
            return (value is Enum) ?
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description ?? string.Empty : string.Empty;
        }

        public static T GetValue<T>(string name)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == name)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }

        public static dynamic GetValue(Type type, string name)
        {
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == name)
                    {
                        return field.GetValue(null);
                    }
                    else if (field.Name == name)
                    {
                        return field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == name)
                        return field.GetValue(null);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }

        public static T Convert<T>(object value)
        {
            if (typeof(T).IsEnum)
                return GetValue<T>(value.ToString());

            return (T)System.Convert.ChangeType(value ?? default(T), typeof(T));
        }
    }
}