using System;
using System.ComponentModel;
using System.Reflection;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class EnumExtension
    {
        public static TEnum ToEnum<TEnum>(this sbyte value) where TEnum : Enum
        {
            return ((int)value).ToEnum<TEnum>();
        }

        public static TEnum ToEnum<TEnum>(this byte value) where TEnum : Enum
        {
            return ((int)value).ToEnum<TEnum>();
        }

        public static TEnum ToEnum<TEnum>(this short value) where TEnum : Enum
        {
            return ((int)value).ToEnum<TEnum>();
        }

        public static TEnum ToEnum<TEnum>(this ushort value) where TEnum : Enum
        {
            return ((uint)value).ToEnum<TEnum>();
        }

        public static TEnum ToEnum<TEnum>(this int value) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                return (TEnum)(object)value;
            }

            throw new ArgumentException($"The value '{value}' is not a valid representation of {typeof(TEnum).Name}.");
        }

        public static TEnum ToEnum<TEnum>(this uint value) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                return (TEnum)(object)value;
            }

            throw new ArgumentException($"The value '{value}' is not a valid representation of {typeof(TEnum).Name}.");
        }

        public static T GetEnumFromDescription<T>(this string description) where T : Enum
        {
            Type? typeFromHandle = typeof(T);
            if (!typeFromHandle.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            FieldInfo[] fields = typeFromHandle.GetFields();
            foreach (FieldInfo fieldInfo in fields)
            {
                if (Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute)
                {
                    if (descriptionAttribute.Description == description)
                    {
                        return (T)fieldInfo.GetValue(null);
                    }
                }
                else if (fieldInfo.Name == description)
                {
                    return (T)fieldInfo.GetValue(null);
                }
            }

            throw new ArgumentException("Enum value not found for description: " + description);
        }

        public static string ToDescription(this Enum value)
        {
            DescriptionAttribute[] array = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
            if (array.Length == 0)
            {
                return value.ToString();
            }

            return array[0].Description;
        }

        private static string GetDescription(object value)
        {
            DescriptionAttribute[] array = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
            if (array.Length == 0)
            {
                return value.ToString();
            }

            return array[0].Description;
        }
    }
}
