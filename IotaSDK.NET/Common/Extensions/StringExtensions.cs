namespace IotaSDK.NET.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool HasError(this string value) =>
            value.Contains("{\"type\":\"error\"");
    }
}
