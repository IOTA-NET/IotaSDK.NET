using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareClaimOutputs
{
    internal class PrepareClaimOutputsCommandModelData
    {
        public PrepareClaimOutputsCommandModelData(List<string> outputIdsToClaim)
        {
            OutputIdsToClaim = outputIdsToClaim;
        }

        public List<string> OutputIdsToClaim { get; }
    }
}
