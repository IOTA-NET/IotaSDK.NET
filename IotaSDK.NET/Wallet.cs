using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Contexts.WalletContext.Commands.AuthenticateToStronghold;
using IotaSDK.NET.Contexts.WalletContext.Commands.CreateAccount;
using IotaSDK.NET.Contexts.WalletContext.Commands.DeleteLatestAccount;
using IotaSDK.NET.Contexts.WalletContext.Commands.SetStrongholdPasswordClearInterval;
using IotaSDK.NET.Contexts.WalletContext.Commands.StoreMnemonic;
using IotaSDK.NET.Contexts.WalletContext.Queries.CheckIfStrongholdPasswordExists;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountIndexes;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.Builders;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET
{
    public class Wallet : IWallet
    {
        private WalletOptions _walletOptions;
        private IntPtr _walletHandle;
        private IMediator _mediator;
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly RustBridgeCommon _rustBridgeCommon;

        public Wallet(IMediator mediator, RustBridgeWallet rustBridgeWallet, RustBridgeCommon rustBridgeCommon)
        {
            _walletOptions = new WalletOptions();

            _walletHandle = IntPtr.Zero;

            _mediator = mediator;
            _rustBridgeWallet = rustBridgeWallet;
            _rustBridgeCommon = rustBridgeCommon;
        }
        public async Task<IWallet> InitializeAsync()
        {
            string walletOptions = JsonConvert.SerializeObject(GetWalletOptions());

            IntPtr? walletHandle = await _rustBridgeWallet.CreateWalletAsync(walletOptions);

            if(walletHandle.HasValue == false)
            {
                string? error = await _rustBridgeCommon.GetLastErrorAsync();
                throw new IotaSDKException($"Unable to create wallet.\nError:{error}");
            }

            _walletHandle = walletHandle!.Value;

            return this;
        }

        public ClientOptionsBuilder ConfigureClientOptions()
            => new ClientOptionsBuilder(this);

        public SecretManagerOptionsBuilder ConfigureSecretManagerOptions()
            => new SecretManagerOptionsBuilder(this);

        public WalletOptionsBuilder ConfigureWalletOptions()
            => new WalletOptionsBuilder(this);

        public WalletOptions GetWalletOptions()
        {
            return _walletOptions;
        }

        public void Dispose()
        {
            _rustBridgeWallet.DestroyWalletAsync(_walletHandle).Wait();
            _walletHandle = IntPtr.Zero;
        }

        public async Task StoreMnemonicAsync(string mnemonic)
        {
            await _mediator.Send(new StoreMnemonicCommand(_walletHandle, mnemonic));
        }

        public async Task<IotaSDKResponse<bool>> CheckIfStrongholdPasswordExistsAsync()
        {
            return await _mediator.Send(new CheckIfStrongholdPasswordExistsQuery(_walletHandle));
        }

        public async Task<IotaSDKResponse<bool>> AuthenticateToStrongholdAsync(string password)
        {
            return await _mediator.Send(new AuthenticateToStrongholdCommand(_walletHandle, password));
        }

        public async Task<IotaSDKResponse<IAccount>> CreateAccountAsync(string? username=null)
        {
            return await _mediator.Send(new CreateAccountCommand(_walletHandle, username));
        }

        public async Task<IotaSDKResponse<bool>> DeleteLatestAccountAsync()
        {
            return await _mediator.Send(new DeleteLatestAccountCommand(_walletHandle));
        }

        public async Task<IotaSDKResponse<bool>> SetStrongholdPasswordClearIntervalAsync(int intervalInMilliSeconds)
        {
            return await _mediator.Send(new SetStrongholdPasswordClearIntervalCommand(_walletHandle, intervalInMilliSeconds));
        }

        public async Task<IotaSDKResponse<List<int>>> GetAccountIndexesAsync()
        {
            return await _mediator.Send(new GetAccountIndexesQuery(_walletHandle));
        }

        public async Task<IotaSDKResponse<IAccount>> GetAccountAsync(int accountIndex)
        {
            return await _mediator.Send(new GetAccountWithIndexQuery(_walletHandle, accountIndex));
        }

        public async Task<IotaSDKResponse<IAccount>> GetAccountAsync(string accountAlias)
        {
            return await _mediator.Send(new GetAccountWithAliasQuery(_walletHandle, accountAlias));
        }

        public async Task<IotaSDKResponse<List<IAccount>>> GetAccountsAsync()
        {
            return await _mediator.Send(new GetAccountsQuery(_walletHandle));
        }
    }

}
