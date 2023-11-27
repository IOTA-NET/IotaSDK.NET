using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Coin;
using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Domain.Options.Builders
{
    internal class WalletOptionsBuilder
    {
        private readonly IWallet _wallet;
        private readonly WalletOptions _walletOptions;
        public WalletOptionsBuilder(IWallet wallet)
        {
            _wallet = wallet;
            _walletOptions = _wallet.GetWalletOptions();
        }

        public WalletOptionsBuilder SetStoragePath(string storagePath)
        {
            _walletOptions.StoragePath = storagePath;
            return this;
        }

        public WalletOptionsBuilder SetCoinType(TypeOfCoin coinType)
        {
            _walletOptions.CoinType = (int)coinType;
            return this;
        }

        public IWallet Then() => _wallet;
    }

}
