using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.Outputs
{
    /// <summary>
    /// An output with Metadata
    /// </summary>
    public class OutputData
    {
        public OutputData(
            string outputId,
            string networkId,
            Address address,
            Output output,
            OutputMetadataResponse outputMetadata
            )
        {
            OutputId = outputId;
            NetworkId = networkId;
            Address = address;
            Output = output;
            Metadata = outputMetadata;
        }

        /// <summary>
        /// The identifier of an Output
        /// </summary>
        public string OutputId { get; set; }

        /// <summary>
        /// If an output is spent
        /// </summary>
        public bool IsSpent { get; set; }

        public string NetworkId { get; set; }

        public bool Remainder { get; set; }

        /// <summary>
        /// Associated account address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// The actual Output
        /// </summary>
        public Output Output { get; set; }

        /// <summary>
        /// The metadata of the output
        /// </summary>
        public OutputMetadataResponse Metadata { get; set; }
    }
}
