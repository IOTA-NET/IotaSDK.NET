using IotaSDK.NET.Domain.Outputs;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutputs
{
    internal class GetOutputsQueryModelData
    {
        public GetOutputsQueryModelData(OutputFilterOptions? filterOptions)
        {
            FilterOptions = filterOptions;
        }

        public OutputFilterOptions? FilterOptions { get; }
    }
}
