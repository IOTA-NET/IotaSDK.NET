using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.Builders;
using System;
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
    }
}
