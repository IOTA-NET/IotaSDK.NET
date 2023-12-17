using IotaSDK.NET.Domain.Outputs;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetUnspentOutputs
{
    internal class GetUnspentOutputsQueryModelData
    {
        public GetUnspentOutputsQueryModelData(OutputFilterOptions? filterOptions)
        {
            FilterOptions = filterOptions;
        }

        public OutputFilterOptions? FilterOptions { get; }
    }
}
