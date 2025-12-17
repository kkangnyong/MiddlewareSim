using System;
using System.Collections.Generic;
using System.Text;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class StringExtension
    {
        public static double ToDouble(this string value)
        {
            return Convert.ToDouble(value);
        }

        public static float ToFloat(this string value)
        {
            return Convert.ToSingle(value);
        }

        public static byte ToByte(this string value)
        {
            return Convert.ToByte(value);
        }

        public static sbyte ToSByte(this string value)
        {
            return Convert.ToSByte(value);
        }

        public static short ToInt16(this string value)
        {
            return Convert.ToInt16(value);
        }

        public static ushort ToUInt16(this string value)
        {
            return Convert.ToUInt16(value);
        }

        public static int ToInt32(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static uint ToUInt32(this string value)
        {
            return Convert.ToUInt32(value);
        }

        public static string GetBetweenStr(this string value, string startStr, string endStr, bool bInclude = false)
        {
            string text = string.Empty;
            int num = value.IndexOf(startStr);
            if (num < 0)
            {
                return text;
            }

            if (!bInclude)
            {
                num += startStr.Length;
            }

            int num2 = value.IndexOf(endStr, num);
            if (num2 < 0)
            {
                return text;
            }

            if (bInclude)
            {
                num2 += endStr.Length;
            }

            for (int i = num; i < num2; i++)
            {
                text += value[i];
            }

            return text;
        }

        public static string Repeat(this string value, int count)
        {
            if (value == null)
            {
                return string.Empty;
            }

            string text = string.Empty;
            for (int i = 0; i < count; i++)
            {
                text += value;
            }

            return text;
        }

        public static byte[] ToEncodingArray(this string value, Encoding encoding)
        {
            if (value == null)
            {
                return new List<byte>().ToArray();
            }

            return encoding.GetBytes(value);
        }

        public static byte[] ToDefaultArray(this string value)
        {
            return value.ToEncodingArray(Encoding.Default);
        }

        public static byte[] ToASCIIArray(this string value)
        {
            return value.ToEncodingArray(Encoding.ASCII);
        }

        public static byte[] ToUTF7Array(this string value)
        {
            return value.ToEncodingArray(Encoding.UTF7);
        }

        public static byte[] ToUTF8Array(this string value)
        {
            return value.ToEncodingArray(Encoding.UTF8);
        }

        public static byte[] ToUTF16Array(this string value)
        {
            return value.ToEncodingArray(Encoding.Unicode);
        }

        public static byte[] ToUTF32Array(this string value)
        {
            return value.ToEncodingArray(Encoding.UTF32);
        }
    }
}
