namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetClaimableOutputs
{
    internal class GetClaimableOutputsQueryModelData
    {
        public GetClaimableOutputsQueryModelData(string outputsToClaim)
        {
            OutputsToClaim = outputsToClaim;
        }

        public string OutputsToClaim { get; }
    }
}
