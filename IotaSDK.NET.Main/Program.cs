using IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Check_Balance;
using IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Create_Wallet_and_Account;
using IotaSDK.NET.Main.Examples.Native_Tokens.Creating_a_Foundry;
using IotaSDK.NET.Main.Examples.Native_Tokens.SendNativeTokens;
using IotaSDK.NET.Main.Examples.Nfts.Burn_an_NFT;
using IotaSDK.NET.Main.Examples.Nfts.Mint_an_NFT;
using IotaSDK.NET.Main.Examples.Nfts.Send_an_NFT;

namespace IotaSDK.NET.Main
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await CreateWalletAndAccountExample.Run();
            //await CheckBalanceExample.Run();
            //await GenerateAddressExample.Run();
            //await RequestTokensFromFaucetExample.Run();
            //await SendBasecoinTransactionExample.Run();
            //await MintNftExample.Run();
            //await SendNftExample.Run();
            //await BurnNftExample.Run();
            //await CreateFoundryExample.Run();
            //await SendNativeTokensExample.Run();
            //await MeltNativeTokensExample.Run();
            await GetFoundryImmutableMetadataExample.Run();
        }

    }
}