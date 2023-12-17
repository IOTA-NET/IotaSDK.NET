using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Outputs;

namespace IotaSDK.NET.Domain.Inputs
{
    public class InputSigningData
    {
        // The output
        public Output Output { get; set; }

        // The output metadata
        public OutputMetadataResponse OutputMetadata { get; set; }

        // The chain derived from seed, only for ed25519 addresses
        public Bip44 Chain { get; set; }

        // Constructor with default values
        public InputSigningData(Output output, OutputMetadataResponse outputMetadata, Bip44 chain = null)
        {
            Output = output;
            OutputMetadata = outputMetadata;
            Chain = chain;
        }
    }

}
