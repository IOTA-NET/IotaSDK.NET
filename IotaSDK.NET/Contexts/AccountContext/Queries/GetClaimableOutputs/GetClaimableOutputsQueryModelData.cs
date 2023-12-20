namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetClaimableOutputs
{
    internal class GetClaimableOutputsQueryModelData
    {
        public GetClaimableOutputsQueryModelData(string outputs)
        {
            Outputs = outputs;
        }

        public string Outputs { get; }
    }
}
