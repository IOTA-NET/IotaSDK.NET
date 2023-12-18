using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetUnspentOutputs
{
    internal class GetUnspentOutputsQueryHandler : IRequestHandler<GetUnspentOutputsQuery, IotaSDKResponse<List<OutputData>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetUnspentOutputsQueryModelData> _iotaSDKAccountModelCreator;

        public GetUnspentOutputsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetUnspentOutputsQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }


        public async Task<IotaSDKResponse<List<OutputData>>> Handle(GetUnspentOutputsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("unspentOutputs", request.AccountIndex, new GetUnspentOutputsQueryModelData(request.FilterOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<OutputData>>.CreateInstance(accountResponse);

        }
    }
}
