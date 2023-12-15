using IotaSDK.NET.Common.Extensions;

namespace IotaSDK.NET.Domain.Transactions.Payloads
{
    public class TaggedDataPayload : Payload
    {
        public TaggedDataPayload(string tag, string data)
            :base((int)PayloadType.TaggedData)

        {
            Tag = tag.ToHexString();
            Data = data.ToHexString();
        }
        /// <summary>
        /// [HexEncoded] The tag to use to categorize the data.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// [HexEncoded] The index data
        /// </summary>
        public string Data { get; set; }

    }
}
