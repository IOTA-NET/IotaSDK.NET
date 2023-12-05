using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.AliasIdToBech32
{
    internal class AliasIdToBech32Command : RustBridgeRequest<string>
    {
        public AliasIdToBech32Command(string aliasId, HumanReadablePart humanReadablePart, string rustMethodName) : base(rustMethodName)
        {
            HumanReadablePart = humanReadablePart;
            AliasId = aliasId;
        }

        public string AliasId { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
