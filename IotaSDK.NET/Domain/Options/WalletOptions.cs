using IotaSDK.NET.Domain.Coin;
using Newtonsoft.Json;

namespace IotaSDK.NET.Domain.Options
{
    public class WalletOptions
    {
        /** The path to the wallet database. */
        public string StoragePath { get; set; } = "./walletdb";

        /** The type of coin stored with the wallet. */
        public int CoinType { get; set; } = (int)TypeOfCoin.Shimmer;

        /** The secret manager to use. */
        public SecretManagerOptions SecretManager { get; set; }


        /** The node client options. */
        public ClientOptions ClientOptions { get; set; }

        public WalletOptions()
        {
            SecretManager = new SecretManagerOptions();
            ClientOptions = new ClientOptions();
        }

    }
}
