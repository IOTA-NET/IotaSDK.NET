using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.RecoverAccounts
{
    internal class RecoverAccountsCommandHandler : IRequestHandler<RecoverAccountsCommand, IotaSDKResponse<List<AccountMeta>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public RecoverAccountsCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<List<AccountMeta>>> Handle(RecoverAccountsCommand request, CancellationToken cancellationToken)
        {
            RecoverAccountsCommandModelData model = new RecoverAccountsCommandModelData(request.AccountStartIndex, request.AccountGapLimit, request.AddressGapLimit, request.SyncOptions);
            
            IotaSDKModel<RecoverAccountsCommandModelData> iotaSDKModel = new IotaSDKModel<RecoverAccountsCommandModelData>("recoverAccounts", model);
            string json = iotaSDKModel.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<List<AccountMeta>>.CreateInstance(walletResponse);

            return response;
        }
    }
}
