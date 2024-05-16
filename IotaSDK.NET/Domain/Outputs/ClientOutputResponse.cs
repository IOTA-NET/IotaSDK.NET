namespace IotaSDK.NET.Domain.Outputs
{
    public class ClientOutputResponse
    {
        /*
         * The metadata about the output.
         * */
        public OutputMetadataResponse Metadata { get; set; } = new OutputMetadataResponse();

        public Output Output { get; set; }
    }
}
