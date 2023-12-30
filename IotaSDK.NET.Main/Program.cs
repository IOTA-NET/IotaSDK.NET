using IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Check_Balance;

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
            await SendNftExample.Run();
        }

    }
}