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
        private readonly IotaSDKAccountModelCreator _iotaSDKAccountModelCreator;

        public GetAddressesQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<List<AccountAddress>>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("addresses", request.AccountIndex);
            string json = accountModel.AsJson();


            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<AccountAddress>>.CreateInstance(accountResponse);

        }
    }
}
