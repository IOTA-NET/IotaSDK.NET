using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareConsolidateOutputs
{
    internal class PrepareConsolidateOutputsCommandModelData
    {
        public PrepareConsolidateOutputsCommandModelData(ConsolidationOptions @params)
        {
            Params = @params;
        }

        public ConsolidationOptions Params { get; }
    }
}
