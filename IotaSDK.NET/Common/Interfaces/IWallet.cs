﻿using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Events;
using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.Builders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IWallet : IDisposable
    {
        WalletOptions GetWalletOptions();

        IMediator GetMediator();

        IClient GetClient();

        ISecretManager GetSecretManager();

        ClientOptionsBuilder ConfigureClientOptions();
        SecretManagerOptionsBuilder ConfigureSecretManagerOptions();
        WalletOptionsBuilder ConfigureWalletOptions();

        Task StoreMnemonicAsync(string mnemonic);

        Task<IWallet> InitializeAsync();
        Task<IotaSDKResponse<bool>> CheckIfStrongholdPasswordExistsAsync();

        Task<IotaSDKResponse<bool>> AuthenticateToStrongholdAsync(string password);

        Task<List<IAccount>> RecoverAccountsAsync(int accountStartIndex, int accountGapLimit, int addressGapLimit, SyncOptions syncOptions);

        Task<IotaSDKResponse<IAccount>> CreateAccountAsync(string? username = null);

        Task<IotaSDKResponse<bool>> DeleteLatestAccountAsync();

        Task<IotaSDKResponse<bool>> SetStrongholdPasswordClearIntervalAsync(int intervalInMilliSeconds);

        Task<IotaSDKResponse<List<int>>> GetAccountIndexesAsync();

        Task<IotaSDKResponse<IAccount>> GetAccountAsync(int accountIndex);

        Task<IotaSDKResponse<IAccount>> GetAccountAsync(string accountAlias);

        Task<IotaSDKResponse<List<IAccount>>> GetAccountsAsync();

        Task<IotaSDKResponse<bool>> ClearStrongholdPasswordAsync();

        Task<IotaSDKResponse<bool>> ChangeStrongholdPasswordAsync(string currentPassword, string newPassword);

        Task<IotaSDKResponse<bool>> StartBackgroundSyncAsync(SyncOptions? syncOptions = null, ulong? intervalInMilliseconds = null);

        Task<IotaSDKResponse<bool>> StopBackgroundSyncAsync();

        Task<IotaSDKResponse<bool>> SetClientOptionsAsync(ClientOptions clientOptions);

        Task<IotaSDKResponse<bool>> BackupStrongholdAsync(string destinationPath, string password);

        Task<IotaSDKResponse<bool>> RestoreBackupAsync(string sourcePath, string password, bool ignoreIfCoinTypeMismatch = true, bool ignoreIfBech32Mismatch = true);

        Task<IotaSDKResponse<string>> GenerateEd25519AddressCommandAsync(int accountIndex, int addressIndex, AddressGenerationOptions? addressGenerationOptions = null, HumanReadablePart? bech32Hrp = null);

        Task<IotaSDKResponse<bool>> SubscribeToEventsAsync(WalletEventType walletEventTypes);

        Task UnsubscribeToEventsAsync(WalletEventType walletEventTypes);

        public event EventHandler<WalletEventNotification> OnConsolidationRequired;
        public event EventHandler<WalletEventNotification> OnLedgerAddressGeneration;
        public event EventHandler<WalletEventNotification> OnNewOutput;
        public event EventHandler<WalletEventNotification> OnSpentOutput;
        public event EventHandler<WalletEventNotification> OnTransactionInclusion;
        public event EventHandler<WalletEventNotification> OnTransactionProgress;
    }
}
