using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Outputs;

namespace IotaSDK.NET.Domain.Inputs
{
    public class TransactionInput
    {
        // The output
        public Output Output { get; set; }

        // The output metadata
        public OutputMetadataResponse Metadata { get; set; }


        // Constructor with default values
        public TransactionInput(Output output, OutputMetadataResponse metadata)
        {
            Output = output;
            Metadata = metadata;
        }
    }
}
