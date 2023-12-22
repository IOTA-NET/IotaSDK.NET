using System;
using System.Text;

namespace IotaSDK.NET.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool HasError(this string value) =>
            value != null && value.Contains("{\"type\":\"error\"");

        public static bool IsNullOrEmpty(this string? input) => string.IsNullOrEmpty(input);

        public static bool IsNotNullAndEmpty(this string? input) => !input.IsNullOrEmpty();

        public static string ToHexString(this string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return "0x" + BitConverter.ToString(bytes).Replace("-", "");
        }

        public static string FromHexString(this string hexString)
        {
            if (hexString.ToLower().StartsWith("0x"))
                hexString = hexString.Substring(2); // remove the 0x of a hexstring eg 0x1337

            // eg 0x0 becomes 0 then becomes 00, to be able to use fromhexstring, we need length of hexstring to be % 2
            if (hexString.Length % 2 != 0)
                hexString = $"0{hexString}";

            int numberChars = hexString.Length / 2;
            byte[] bytes = new byte[numberChars];

            for (int i = 0; i < numberChars; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.UTF8.GetString(bytes);
        }

    }

}
