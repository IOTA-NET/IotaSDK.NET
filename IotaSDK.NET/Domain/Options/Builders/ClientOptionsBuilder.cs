using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Domain.Options.Builders
{
    public class ClientOptionsBuilder
    {
        private readonly IWallet _wallet;
        private readonly ClientOptions _clientOptions;

        public ClientOptionsBuilder(IWallet wallet)
        {
            _wallet = wallet;
            _clientOptions = _wallet.GetWalletOptions().ClientOptions;
        }

        public ClientOptionsBuilder AddNodeUrl(string nodeUrl)
        {
            _clientOptions.Nodes.Add(nodeUrl);
            return this;
        }

        public ClientOptionsBuilder IsLocalPow(bool isLocalPow = true)
        {
            _clientOptions.LocalPow = isLocalPow;
            return this;
        }

        public ClientOptionsBuilder SetFaucetUrl(string faucetUrl)
        {
            _clientOptions.FaucetUrl = faucetUrl;
            return this;
        }

        public IWallet Then()
        {
            //To trigger json re-construction
            _wallet.GetWalletOptions().ClientOptions = _clientOptions;
            return _wallet;
        }
    }
}
