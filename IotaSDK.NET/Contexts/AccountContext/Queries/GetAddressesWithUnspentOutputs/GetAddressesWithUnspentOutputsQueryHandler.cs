using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Addresses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetAddressesWithUnspentOutputs
{
    internal class GetAddressesWithUnspentOutputsQueryHandler : IRequestHandler<GetAddressesWithUnspentOutputsQuery, IotaSDKResponse<List<AddressWithUnspentOutputs>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator _iotaSDKAccountModelCreator;

        public GetAddressesWithUnspentOutputsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<List<AddressWithUnspentOutputs>>> Handle(GetAddressesWithUnspentOutputsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("addressesWithUnspentOutputs", request.AccountIndex);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<AddressWithUnspentOutputs>>.CreateInstance(accountResponse);
        }
    }
}
