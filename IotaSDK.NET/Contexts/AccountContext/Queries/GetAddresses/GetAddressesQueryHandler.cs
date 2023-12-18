using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Addresses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetAddresses
{
    internal class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IotaSDKResponse<List<AccountAddress>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAddressesQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<List<AccountAddress>>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel innerModel = new IotaSDKModel("addresses");

            AccountModelData accountModelData = new AccountModelData(request.AccountIndex, innerModel);
            IotaSDKAccountModel model = new IotaSDKAccountModel(accountModelData);
            string json = model.AsJson();


            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<AccountAddress>>.CreateInstance(accountResponse);

        }
    }
}
