using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput
{
    internal class GetOutputQueryHandler : IRequestHandler<GetOutputQuery, IotaSDKResponse<OutputData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetOutputQueryModelData> _iotaSDKAccountModelCreator;

        public GetOutputQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetOutputQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<OutputData>> Handle(GetOutputQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getOutput", request.AccountIndex, new GetOutputQueryModelData(request.OutputId));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<OutputData>.CreateInstance(accountResponse);
        }
    }
}
