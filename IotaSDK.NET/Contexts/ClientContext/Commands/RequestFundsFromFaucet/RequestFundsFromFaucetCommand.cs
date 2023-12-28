using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Faucet;
using System;

namespace IotaSDK.NET.Contexts.ClientContext.Commands.RequestFundsFromFaucet
{
    internal class RequestFundsFromFaucetCommand : ClientRequest<IotaSDKResponse<FaucetResponse>>
    {
        public RequestFundsFromFaucetCommand(IntPtr walletHandle, string bech32Address, string faucetUrl = "https://faucet.testnet.shimmer.network/api/enqueue") : base(walletHandle)
        {
            Bech32Address = bech32Address;
            FaucetUrl = faucetUrl;
        }

        public string Bech32Address { get; }
        public string FaucetUrl { get; }
    }
}
