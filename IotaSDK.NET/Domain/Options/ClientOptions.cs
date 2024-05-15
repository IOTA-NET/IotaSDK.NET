using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Options
{
    public class ClientOptions
    {
        public HashSet<string> Nodes { get; set; } = new HashSet<string>() { };

        public bool LocalPow { get; set; } = true;

        public string FaucetUrl { get; set; } = "https://faucet.testnet.shimmer.network";
    }
}
