using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class NumericExtension
    {
        public static bool IsInRange(this byte? value, byte minValue, byte maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this sbyte? value, sbyte minValue, sbyte maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this short? value, short minValue, short maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this ushort? value, ushort minValue, ushort maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this int? value, int minValue, int maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this uint? value, uint minValue, uint maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this long? value, long minValue, long maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this ulong? value, ulong minValue, ulong maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this BigInteger? value, BigInteger minValue, BigInteger maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this float? value, float minValue, float maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this double? value, double minValue, double maxValue)
        {
            if (value.HasValue)
            {
                return value.Value.IsInRange(minValue, maxValue);
            }

            return false;
        }

        public static bool IsInRange(this byte value, byte minValue, byte maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this sbyte value, sbyte minValue, sbyte maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this short value, short minValue, short maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this ushort value, ushort minValue, ushort maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this int value, int minValue, int maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this uint value, uint minValue, uint maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this long value, long minValue, long maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this ulong value, ulong minValue, ulong maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this BigInteger value, BigInteger minValue, BigInteger maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this float value, float minValue, float maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static bool IsInRange(this double value, double minValue, double maxValue)
        {
            if (minValue <= value)
            {
                return value <= maxValue;
            }

            return false;
        }

        public static string ToPrefixedHexString<T>(this T number, bool separated = false) where T : struct, IComparable, IFormattable, IConvertible
        {
            byte[] array = number.SerializeUsingMarshal();
            IEnumerable<byte> value;
            if (!BitConverter.IsLittleEndian)
            {
                IEnumerable<byte> enumerable = array;
                value = enumerable;
            }
            else
            {
                value = array.Reverse();
            }

            return value.ToPrefixedHexString(separated);
        }

        public static string ToUnPrefixedHexString<T>(this T number, string connector = " ") where T : struct, IComparable, IFormattable, IConvertible
        {
            byte[] array = number.SerializeUsingMarshal();
            IEnumerable<byte> data;
            if (!BitConverter.IsLittleEndian)
            {
                IEnumerable<byte> enumerable = array;
                data = enumerable;
            }
            else
            {
                data = array.Reverse();
            }

            return data.ToUnPrefixedHexString(connector);
        }

        public static string ToSIPrefix<T>(this T number, SIPrefixUnit unit = SIPrefixUnit.Auto, int decimalCount = 2) where T : struct, IComparable, IFormattable, IConvertible
        {
            return number.ToSIPrefixCore(unit, decimalCount);
        }

        internal static string ToSIPrefixCore<T>(this T number, SIPrefixUnit unit, int decimalCount) where T : struct, IComparable, IFormattable, IConvertible
        {
            double num = Convert.ToDouble(number);
            string[] array = new string[9] { "", " m", "μ", " n", " p", " f", " a", " z", " y" };
            string[] array2 = new string[9] { "", " k", " M", " G", " T", " P", " E", " Z", " Y" };
            int num2 = (int)unit;
            string empty = string.Empty;
            if (num2 == 0)
            {
                if (num >= 1.0)
                {
                    return num.FindSuitableValueInteger(decimalCount);
                }

                return num.FindSuitableValueForDecimal(decimalCount);
            }

            if (num2 < 100)
            {
                for (int i = 0; i < num2; i++)
                {
                    num *= 1000.0;
                }

                string text = "0." + new string('#', decimalCount);
                return num.ToString(text) + array[num2];
            }

            num2 -= 100;
            num /= Math.Pow(1000.0, num2);
            string text2 = "0." + new string('#', decimalCount);
            return num.ToString(text2) + array2[num2];
        }

        internal static string FindSuitableValueInteger(this double value, int decimalCount)
        {
            string[] array = new string[9] { "", " k", " M", " G", " T", " P", " E", " Z", " Y" };
            int num = 0;
            while (Math.Abs(value) >= 1000.0 && num < array.Length - 1)
            {
                value /= 1000.0;
                num++;
            }

            string text = "0." + new string('#', decimalCount);
            return value.ToString(text) + array[num];
        }

        internal static string FindSuitableValueForDecimal(this double value, int decimalCount)
        {
            string[] array = new string[9] { "", " m", "µ", " n", " p", " f", " a", " z", " y" };
            int num = 0;
            while (value < 1.0 && num > -array.Length + 1)
            {
                value *= 1000.0;
                num--;
            }

            string text = "0." + new string('#', decimalCount);
            return value.ToString(text) + array[-num];
        }

        public static byte[] ToByteArray<T>(this T data) where T : struct, IComparable, IFormattable, IConvertible
        {
            return data.SerializeUsingMarshal();
        }

        public static short HostToNetworkEndian(this short data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return IPAddress.HostToNetworkOrder(data);
        }

        public static short NetworkToHostEndian(this short data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return IPAddress.NetworkToHostOrder(data);
        }

        public static ushort HostToNetworkEndian(this ushort data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return (ushort)IPAddress.HostToNetworkOrder((short)data);
        }

        public static ushort NetworkToHostEndian(this ushort data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return (ushort)IPAddress.NetworkToHostOrder((short)data);
        }

        public static uint HostToNetworkEndian(this uint data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return (uint)IPAddress.HostToNetworkOrder((int)data);
        }

        public static uint NetworkToHostEndian(this uint data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return (uint)IPAddress.NetworkToHostOrder((int)data);
        }

        public static int HostToNetworkEndian(this int data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return IPAddress.HostToNetworkOrder(data);
        }

        public static int NetworkToHostEndian(this int data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return IPAddress.NetworkToHostOrder(data);
        }

        public static ulong HostToNetworkEndian(this ulong data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return (ulong)IPAddress.HostToNetworkOrder((long)data);
        }

        public static ulong NetworkToHostEndian(this ulong data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return (ulong)IPAddress.NetworkToHostOrder((long)data);
        }

        public static long HostToNetworkEndian(this long data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return IPAddress.HostToNetworkOrder(data);
        }

        public static long NetworkToHostEndian(this long data)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return data;
            }

            return IPAddress.NetworkToHostOrder(data);
        }

        public static float HostToNetworkEndian(this float data)
        {
            byte[] bytes = BitConverter.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToSingle(bytes, 0);
        }

        public static float NetworkToHostEndian(this float data)
        {
            byte[] bytes = BitConverter.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToSingle(bytes, 0);
        }

        public static double HostToNetworkEndian(this double data)
        {
            byte[] bytes = BitConverter.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToDouble(bytes, 0);
        }

        public static double NetworkToHostEndian(this double data)
        {
            byte[] bytes = BitConverter.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToDouble(bytes, 0);
        }

        public static double ConvertEndian(this double data)
        {
            byte[] bytes = BitConverter.GetBytes(data);
            Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }

        internal static bool IsNumericType<T>(this T data) where T : struct, IComparable, IFormattable, IConvertible
        {
            bool result = true;
            try
            {
                Convert.ToDouble(data);
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }

    public enum SIPrefixUnit
    {
        Auto = 0,
        Mili = 1,
        Micro = 2,
        Nano = 3,
        Pico = 4,
        Femto = 5,
        Atto = 6,
        Zepto = 7,
        Yocto = 8,
        Kilo = 101,
        Mega = 102,
        Giga = 103,
        Tera = 104,
        Peta = 105,
        Exa = 106,
        Zetta = 107,
        Yotta = 108
    }
}
