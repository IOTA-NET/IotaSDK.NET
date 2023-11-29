using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Domain.Options.Builders
{
    internal class SecretManagerOptionsBuilder
    {
        private readonly IWallet _wallet;
        private readonly StrongholdOptions _strongholdOptions;

        public SecretManagerOptionsBuilder(IWallet wallet)
        {
            _wallet = wallet;
            _strongholdOptions = _wallet.GetWalletOptions().SecretManager.Stronghold;
        }

        public SecretManagerOptionsBuilder SetPassword(string password)
        {
            _strongholdOptions.Password = password;

            return this;
        }

        public SecretManagerOptionsBuilder SetSnapshotPath(string snapshotPath)
        {
            _strongholdOptions.SnapshotPath = snapshotPath;

            return this;
        }

        public IWallet Then()
        {
            //To trigger json re-construction
            _wallet.GetWalletOptions().SecretManager = _wallet.GetWalletOptions().SecretManager;
            return _wallet;
        }
    }
}
