using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Faucet;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RequestFundsFromFaucet
{
    internal class RequestFundsFromFaucetCommand : AccountRequest<IotaSDKResponse<FaucetResponse>>
    {
        public RequestFundsFromFaucetCommand(IntPtr walletHandle, int accountIndex, IClient client, IAccount account, string? bech32Address=null) 
            : base(walletHandle, accountIndex)
        {
            Client = client;
            Account = account;
        }


        public string? Bech32Address { get; }
        public IClient Client { get; }
        public IAccount Account { get; }
    }
}
