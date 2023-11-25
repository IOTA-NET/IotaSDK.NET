using System.Collections.Generic;

namespace IotaSDK.NET.Common.Options
{
    public class ClientOptions
    {
        public HashSet<string> Nodes { get; set; } = new HashSet<string>() { "https://api.testnet.shimmer.network" };

        public bool LocalPow { get; set; } = true;

        public string FaucetUrl { get; set; } = "https://faucet.testnet.shimmer.network";
    }
}
