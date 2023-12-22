using System;

namespace IotaSDK.NET.Common.Extensions
{
    public static class NumberExtensions  
    {
        public static string ToHex(this ulong value)
        {
            return "0x" + value.ToString("X");
        }
        public static string ToHex(this long value)
        {
            return "0x" + value.ToString("X");
        }
        public static string ToHex(this int value)
        {
            return "0x" + value.ToString("X");
        }
        public static string ToHex(this uint value)
        {
            return "0x" + value.ToString("X");
        }

        public static ulong FromHexToULong(this string hexString)
        {
            hexString = hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? hexString.Substring(2) : hexString;
            return ulong.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }

        public static long FromHexToLong(this string hexString)
        {
            hexString = hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? hexString.Substring(2) : hexString;
            return long.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }

        public static int FromHexToInt(this string hexString)
        {
            hexString = hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? hexString.Substring(2) : hexString;
            return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }

        public static uint FromHexToUInt(this string hexString)
        {
            hexString = hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? hexString.Substring(2) : hexString;
            return uint.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
