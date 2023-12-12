using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.Builders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IWallet : IDisposable
    {
        WalletOptions GetWalletOptions();

        ClientOptionsBuilder ConfigureClientOptions();
        SecretManagerOptionsBuilder ConfigureSecretManagerOptions();
        WalletOptionsBuilder ConfigureWalletOptions();

        Task StoreMnemonicAsync(string mnemonic);

        Task<IWallet> InitializeAsync();
        Task<IotaSDKResponse<bool>> CheckIfStrongholdPasswordExistsAsync();
        
        Task<IotaSDKResponse<bool>> AuthenticateToStrongholdAsync(string password);

        Task<IotaSDKResponse<IAccount>> CreateAccountAsync(string? username=null);

        Task<IotaSDKResponse<bool>> DeleteLatestAccountAsync();

        Task<IotaSDKResponse<bool>> SetStrongholdPasswordClearIntervalAsync(int intervalInMilliSeconds);

        Task<IotaSDKResponse<List<int>>> GetAccountIndexesAsync();

        Task<IotaSDKResponse<IAccount>> GetAccountAsync(int accountIndex);

        Task<IotaSDKResponse<IAccount>> GetAccountAsync(string accountAlias);
        
        Task<IotaSDKResponse<List<IAccount>>> GetAccountsAsync();

        Task<IotaSDKResponse<bool>> ClearStrongholdPasswordAsync();

        Task<IotaSDKResponse<bool>> ChangeStrongholdPasswordAsync(string currentPassword, string newPassword);

    }
}
