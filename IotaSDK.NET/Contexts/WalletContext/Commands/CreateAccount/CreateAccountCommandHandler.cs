﻿using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.CreateAccount
{
    internal class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, IotaSDKResponse<AccountMeta>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public CreateAccountCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<AccountMeta>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            CreateAccountCommandModelData modelData = string.IsNullOrEmpty(request.Username)
                                                        ? new CreateAccountCommandModelData()
                                                        : new CreateAccountCommandModelData(request.Username);


            IotaSDKModel<CreateAccountCommandModelData> model = new IotaSDKModel<CreateAccountCommandModelData>("createAccount", modelData);

            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<AccountMeta>.CreateInstance(walletResponse);

            return response;
        }
    }
}
