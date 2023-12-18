using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
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

        public GetUnspentOutputsQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }


        public async Task<IotaSDKResponse<List<OutputData>>> Handle(GetUnspentOutputsQuery request, CancellationToken cancellationToken)
        {
            GetUnspentOutputsQueryModelData innerModelData = new GetUnspentOutputsQueryModelData(request.FilterOptions);
            IotaSDKModel<GetUnspentOutputsQueryModelData> innerModel = new IotaSDKModel<GetUnspentOutputsQueryModelData>("unspentOutputs", innerModelData);
            AccountModelData<GetUnspentOutputsQueryModelData> accountModelData = new AccountModelData<GetUnspentOutputsQueryModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<GetUnspentOutputsQueryModelData> accountModel = new IotaSDKAccountModel<GetUnspentOutputsQueryModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<OutputData>>.CreateInstance(accountResponse);

        }
    }
}
