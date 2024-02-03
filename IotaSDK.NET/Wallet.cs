using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Contexts.WalletContext.Commands.AuthenticateToStronghold;
using IotaSDK.NET.Contexts.WalletContext.Commands.BackupStronghold;
using IotaSDK.NET.Contexts.WalletContext.Commands.ChangeStrongholdPassword;
using IotaSDK.NET.Contexts.WalletContext.Commands.ClearStrongholdPassword;
using IotaSDK.NET.Contexts.WalletContext.Commands.CreateAccount;
using IotaSDK.NET.Contexts.WalletContext.Commands.DeleteLatestAccount;
using IotaSDK.NET.Contexts.WalletContext.Commands.GenerateEd25519Address;
using IotaSDK.NET.Contexts.WalletContext.Commands.RestoreBackup;
using IotaSDK.NET.Contexts.WalletContext.Commands.SetClientOptions;
using IotaSDK.NET.Contexts.WalletContext.Commands.SetStrongholdPasswordClearInterval;
using IotaSDK.NET.Contexts.WalletContext.Commands.StartBackgroundSync;
using IotaSDK.NET.Contexts.WalletContext.Commands.StopBackgroundSync;
using IotaSDK.NET.Contexts.WalletContext.Commands.StoreMnemonic;
using IotaSDK.NET.Contexts.WalletContext.Commands.SubscribeToEvents;
using IotaSDK.NET.Contexts.WalletContext.Commands.UnsubscribeToEvents;
using IotaSDK.NET.Contexts.WalletContext.Queries.CheckIfStrongholdPasswordExists;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountIndexes;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias;
using IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Events;
using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.Builders;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        private IClient? _client;
        private IAccount? _account;

        public Wallet(IMediator mediator, RustBridgeWallet rustBridgeWallet, RustBridgeCommon rustBridgeCommon)
        {
            _walletOptions = new WalletOptions();

            _walletHandle = IntPtr.Zero;

            _mediator = mediator;
            _rustBridgeWallet = rustBridgeWallet;
            _rustBridgeCommon = rustBridgeCommon;
            _account = null;
            _client = null;
        }

        public async Task<IWallet> InitializeAsync()
        {
            string walletOptions = JsonConvert.SerializeObject(GetWalletOptions());

            IntPtr? walletHandle = await _rustBridgeWallet.CreateWalletAsync(walletOptions);

            if (walletHandle.HasValue == false)
            {
                string? error = await _rustBridgeCommon.GetLastErrorAsync();
                throw new IotaSDKException($"Unable to create wallet.\nError:{error}");
            }

            _walletHandle = walletHandle!.Value;

            IntPtr? clientHandle = await _rustBridgeWallet.GetClientFromWalletAsync(_walletHandle);

            if (clientHandle.HasValue == false)
            {
                string? error = await _rustBridgeCommon.GetLastErrorAsync();
                throw new IotaSDKException($"Unable to create client.\nError:{error}");
            }

            _client = new Client(_mediator, clientHandle.Value, faucetUrl: _walletOptions.ClientOptions.FaucetUrl);

            return this;
        }

        public IClient GetClient()
            => _client!;
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

        public async Task<IotaSDKResponse<IAccount>> CreateAccountAsync(string? username = null)
        {
            IotaSDKResponse<AccountMeta> iotaSDKResponse = await _mediator.Send(new CreateAccountCommand(_walletHandle, username));
            IAccount account = new Account(_walletHandle, this, _mediator, iotaSDKResponse.Payload.Index, iotaSDKResponse.Payload.Alias);
            return new IotaSDKResponse<IAccount>(iotaSDKResponse.Type) { Payload = account };
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
            IotaSDKResponse<AccountMeta> iotaSDKResponse = await _mediator.Send(new GetAccountWithIndexQuery(_walletHandle, accountIndex));
            IAccount account = new Account(_walletHandle, this, _mediator, iotaSDKResponse.Payload.Index, iotaSDKResponse.Payload.Alias);
            return new IotaSDKResponse<IAccount>(iotaSDKResponse.Type) { Payload = account };
        }

        public async Task<IotaSDKResponse<IAccount>> GetAccountAsync(string accountAlias)
        {
            IotaSDKResponse<AccountMeta> iotaSDKResponse = await _mediator.Send(new GetAccountWithAliasQuery(_walletHandle, accountAlias));
            IAccount account = new Account(_walletHandle, this, _mediator, iotaSDKResponse.Payload.Index, iotaSDKResponse.Payload.Alias);
            return new IotaSDKResponse<IAccount>(iotaSDKResponse.Type) { Payload = account };
        }

        public async Task<IotaSDKResponse<List<IAccount>>> GetAccountsAsync()
        {
            IotaSDKResponse<List<AccountMeta>> iotaSDKResponse = await _mediator.Send(new GetAccountsQuery(_walletHandle));
            List<IAccount> accountList = new List<IAccount>();

            var accountMetas = iotaSDKResponse.Payload;

            foreach (var accountMeta in accountMetas)
            {
                IAccount account = new Account(_walletHandle, this, _mediator, accountMeta.Index, accountMeta.Alias);
                accountList.Add(account);
            }

            return new IotaSDKResponse<List<IAccount>>(iotaSDKResponse.Type) { Payload = accountList };
        }

        public async Task<IotaSDKResponse<bool>> ClearStrongholdPasswordAsync()
        {
            return await _mediator.Send(new ClearStrongholdPasswordCommand(_walletHandle));
        }

        public async Task<IotaSDKResponse<bool>> ChangeStrongholdPasswordAsync(string currentPassword, string newPassword)
        {
            return await _mediator.Send(new ChangeStrongholdPasswordCommand(_walletHandle, currentPassword, newPassword));
        }

        public async Task<IotaSDKResponse<bool>> StartBackgroundSyncAsync(SyncOptions? syncOptions = null, ulong? intervalInMilliseconds = null)
        {
            return await _mediator.Send(new StartBackgroundSyncCommand(_walletHandle, syncOptions, intervalInMilliseconds));
        }

        public async Task<IotaSDKResponse<bool>> StopBackgroundSyncAsync()
        {
            return await _mediator.Send(new StopBackgroundSyncCommand(_walletHandle));
        }

        public async Task<IotaSDKResponse<bool>> SetClientOptionsAsync(ClientOptions clientOptions)
        {
            return await _mediator.Send(new SetClientOptionsCommand(clientOptions, _walletHandle));
        }

        public async Task<IotaSDKResponse<bool>> BackupStrongholdAsync(string destinationPath, string password)
        {
            return await _mediator.Send(new BackupStrongholdCommand(_walletHandle, destinationPath, password));
        }

        public async Task<IotaSDKResponse<bool>> RestoreBackupAsync(string sourcePath, string password, bool ignoreIfCoinTypeMismatch = true, bool ignoreIfBech32Mismatch = true)
        {
            return await _mediator.Send(new RestoreBackupCommand(_walletHandle, sourcePath, password, ignoreIfCoinTypeMismatch, ignoreIfBech32Mismatch));
        }

        public async Task<IotaSDKResponse<string>> GenerateEd25519AddressCommandAsync(int accountIndex, int addressIndex, AddressGenerationOptions? addressGenerationOptions = null, HumanReadablePart? bech32Hrp = null)
        {
            return await _mediator.Send(new GenerateEd25519AddressCommand(_walletHandle, accountIndex, addressIndex, addressGenerationOptions, bech32Hrp));
        }

        public async Task<IotaSDKResponse<bool>> SubscribeToEventsAsync(WalletEventType walletEventTypes)
        {
            return await _mediator.Send(new SubscribeToEventsCommand(_walletHandle, walletEventTypes, WalletEventCallback));
        }

        private void WalletEventCallback(IntPtr intPtr)
        {
            if (intPtr == IntPtr.Zero) return;

            string eventJson = Marshal.PtrToStringAnsi(intPtr);
            WalletEventNotification? walletEventNotification = JsonConvert.DeserializeObject<WalletEventNotification>(eventJson);

            if (walletEventNotification == null)
                throw new IotaSDKException($"Unable to deserialize: {eventJson}");

            switch (walletEventNotification.Event.GetWalletEventType())
            {
                case WalletEventType.TransactionInclusion:
                    OnTransactionInclusion?.Invoke(this, walletEventNotification);
                    break;
                case WalletEventType.TransactionProgress:
                    OnTransactionProgress?.Invoke(this, walletEventNotification);
                    break;
                case WalletEventType.LedgerAddressGeneration:
                    OnLedgerAddressGeneration?.Invoke(this, walletEventNotification);
                    break;
                case WalletEventType.ConsolidationRequired:
                    OnConsolidationRequired?.Invoke(this, walletEventNotification);
                    break;
                case WalletEventType.NewOutput:
                    OnNewOutput?.Invoke(this, walletEventNotification);
                    break;
                case WalletEventType.SpentOutput:
                    OnSpentOutput?.Invoke(this, walletEventNotification);
                    break;
            }

        }

        public async Task UnsubscribeToEventsAsync(WalletEventType walletEventTypes)
        {
            await _mediator.Send(new UnsubscribeToEventsCommand(_walletHandle, walletEventTypes));
        }

        public event EventHandler<WalletEventNotification> OnConsolidationRequired = (sender, e) => { };
        public event EventHandler<WalletEventNotification> OnLedgerAddressGeneration = (sender, e) => { };
        public event EventHandler<WalletEventNotification> OnNewOutput = (sender, e) => { };
        public event EventHandler<WalletEventNotification> OnSpentOutput = (sender, e) => { };
        public event EventHandler<WalletEventNotification> OnTransactionInclusion = (sender, e) => { };
        public event EventHandler<WalletEventNotification> OnTransactionProgress = (sender, e) => { };
    }

}
