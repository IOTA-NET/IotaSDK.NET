using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Create_Wallet_and_Account;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            await CreateWalletAndAccountExample.Run();

        }

    }
}