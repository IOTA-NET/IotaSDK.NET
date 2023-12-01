using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.AliasIdToBech32
{
    internal class AliasIdToBech32CommandHandler : IRequestHandler<AliasIdToBech32Command, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public AliasIdToBech32CommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(AliasIdToBech32Command request, CancellationToken cancellationToken)
        {
            AliasIdToBech32CommandModelData modelData = new AliasIdToBech32CommandModelData(request.AliasId, HumanReadablePartEnumConverter.Convert(request.HumanReadablePart));
            IotaSDKModel<AliasIdToBech32CommandModelData> model = new IotaSDKModel<AliasIdToBech32CommandModelData>("aliasIdToBech32", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);
            
            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
