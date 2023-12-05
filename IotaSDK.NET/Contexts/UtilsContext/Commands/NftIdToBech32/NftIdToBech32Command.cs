using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32
{
    internal class NftIdToBech32Command : RustBridgeRequest<string>
    {
        public NftIdToBech32Command(string nftId, HumanReadablePart humanReadablePart, string rustMethodName) : base(rustMethodName)
        {
            NftId = nftId;
            HumanReadablePart = humanReadablePart;
        }

        public string NftId { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
