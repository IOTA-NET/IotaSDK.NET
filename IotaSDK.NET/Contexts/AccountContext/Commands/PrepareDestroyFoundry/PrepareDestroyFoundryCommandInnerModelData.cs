using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyFoundry
{
    internal class PrepareDestroyFoundryCommandInnerModelData
    {
        public PrepareDestroyFoundryCommandInnerModelData(string foundryId)
        {
            Foundries = new List<string>() { foundryId };
        }
        public List<string> Foundries { get; set; }
    }
}
