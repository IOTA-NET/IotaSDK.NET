using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.GenerateEd25519Address
{
    internal class GenerateEd25519AddressCommandHandler : IRequestHandler<GenerateEd25519AddressCommand, IotaSDKResponse<string>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GenerateEd25519AddressCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<string>> Handle(GenerateEd25519AddressCommand request, CancellationToken cancellationToken)
        {
            var modelData = new GenerateEd25519AddressCommandModelData(request.AccountIndex, request.AddressIndex, request.AddressGenerationOptions, request.Bech32Hrp);
            var model = new IotaSDKModel<GenerateEd25519AddressCommandModelData>("generateEd25519Address", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            return IotaSDKResponse<string>.CreateInstance(walletResponse);
        }
    }
}

