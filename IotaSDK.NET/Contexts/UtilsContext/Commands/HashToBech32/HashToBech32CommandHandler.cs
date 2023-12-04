using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.HashToBech32
{
    internal class HashToBech32CommandHandler : IRequestHandler<HashToBech32Command, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public HashToBech32CommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(HashToBech32Command request, CancellationToken cancellationToken)
        {
            HashToBech32CommandModelData modelData = new HashToBech32CommandModelData(request.HexEncodedHash, HumanReadablePartEnumConverter.Convert(request.HumanReadablePart));
            IotaSDKModel<HashToBech32CommandModelData> model = new IotaSDKModel<HashToBech32CommandModelData>("hexToBech32", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);


        }
    }
}
