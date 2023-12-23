using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetFoundryOutput
{
    internal class GetFoundryOutputQueryHandler : IRequestHandler<GetFoundryOutputQuery, IotaSDKResponse<FoundryOutput>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetFoundryOutputQueryModelData> _iotaSDKAccountModelCreator;

        public GetFoundryOutputQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetFoundryOutputQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<FoundryOutput>> Handle(GetFoundryOutputQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getFoundryOutput", request.AccountIndex, new GetFoundryOutputQueryModelData(request.TokenId));
            string json = accountModel.AsJson();


            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<FoundryOutput>.CreateInstance(accountResponse);
        }
    }
}
