using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Addresses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.GenerateEd25519Addresses
{
    internal class GenerateEd25519AddressesCommandHandler : IRequestHandler<GenerateEd25519AddressesCommand, IotaSDKResponse<List<AccountAddress>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GenerateEd25519AddressesCommandModelData> _iotaSDKAccountModelCreator;

        public GenerateEd25519AddressesCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GenerateEd25519AddressesCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<List<AccountAddress>>> Handle(GenerateEd25519AddressesCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("generateEd25519Addresses", request.AccountIndex, new GenerateEd25519AddressesCommandModelData(request.NumberOfAddresses, request.AddressGenerationOptions));
            var json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<AccountAddress>>.CreateInstance(accountResponse);
        }
    }
}
