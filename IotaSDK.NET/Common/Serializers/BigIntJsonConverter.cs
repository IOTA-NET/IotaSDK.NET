using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace IotaSDK.NET.Common.Serializers
{
    internal class BigIntJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            List<Type> validTypes = new List<Type>() { typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(string), typeof(BigInteger) };

            if (validTypes.Contains(objectType))
                return true;
            return false;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var t = reader.ValueType;
            var token = reader.Value as string;

            if (token == null)
                return null;

            if (token.ToLower().StartsWith("0x"))
                token = token.Substring(2);

            // Prepend "0" to ensure it's parsed as a positive number
            token = "0" + token;

            var parsedUnsignedBigInteger = BigInteger.Parse(token, NumberStyles.HexNumber);
            return parsedUnsignedBigInteger;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
                return;

            writer.WriteValue($"0x{(BigInteger)value:X}");
        }
    }
}
