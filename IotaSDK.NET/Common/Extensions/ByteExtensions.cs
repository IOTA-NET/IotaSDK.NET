using System;

namespace IotaSDK.NET.Common.Extensions
{
    public static class ByteExtensions
    {
        public static string ToHexString(this byte[] bytes)
        {
            return "0x" + BitConverter.ToString(bytes).Replace("-", "");
        }

        public static byte[] FromHexStringToBytes(this string hexString)
        {
            hexString = hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? hexString.Substring(2) : hexString;

            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
    }

}
