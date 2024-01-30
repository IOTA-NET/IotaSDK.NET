using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace IotaSDK.NET.Common.Serializers
{
    internal class DictBigIntJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // Check if the objectType is a Dictionary with string keys and BigInteger values
            return objectType == typeof(Dictionary<string, BigInteger>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Initialize the dictionary to store the deserialized values
            var dict = new Dictionary<string, BigInteger>();

            // Load the JSON object from the reader
            JObject jsonObject = JObject.Load(reader);

            foreach (var prop in jsonObject.Properties())
            {
                string key = prop.Name;
                string value = prop.Value.ToString();

                // Process the hex string as in your original converter
                if (value.ToLower().StartsWith("0x"))
                    value = value.Substring(2);

                // Prepend "0" to ensure it's parsed as a positive number
                value = "0" + value;

                // Parse the BigInteger from the hex string
                BigInteger bigIntValue = BigInteger.Parse(value, NumberStyles.HexNumber);

                // Add the key-value pair to the dictionary
                dict.Add(key, bigIntValue);
            }

            return dict;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Cast the value to the correct type
            var dict = (Dictionary<string, BigInteger>)value;

            // Start writing the object
            writer.WriteStartObject();

            foreach (var kvp in dict)
            {
                writer.WritePropertyName(kvp.Key);

                // Convert BigInteger to a hex string and write as a value
                writer.WriteValue($"0x{kvp.Value:X}");
            }

            // End writing the object
            writer.WriteEndObject();
        }
    }
}
