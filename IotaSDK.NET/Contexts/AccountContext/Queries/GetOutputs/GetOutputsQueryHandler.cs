using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutputs
{
    internal class GetOutputsQueryHandler : IRequestHandler<GetOutputsQuery, IotaSDKResponse<List<OutputData>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetOutputsQueryModelData> _iotaSDKAccountModelCreator;

        public GetOutputsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetOutputsQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<List<OutputData>>> Handle(GetOutputsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("outputs", request.AccountIndex, new GetOutputsQueryModelData(request.OutputFilterOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<OutputData>>.CreateInstance(accountResponse);
        }
    }
}
