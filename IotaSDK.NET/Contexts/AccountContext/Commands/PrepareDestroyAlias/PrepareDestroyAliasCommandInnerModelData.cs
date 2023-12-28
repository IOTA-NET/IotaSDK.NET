using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyAlias
{
    internal class PrepareDestroyAliasCommandInnerModelData
    {
        public PrepareDestroyAliasCommandInnerModelData(List<string> aliases)
        {
            Aliases = aliases;
        }

        public List<string> Aliases { get; } = new List<string>();
    }
}
