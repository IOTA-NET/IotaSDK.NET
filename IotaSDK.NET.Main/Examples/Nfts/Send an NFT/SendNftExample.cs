using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Check_Balance
{
    public static class SendNftExample
    {
        public static async Task Run()
        {
            //Register all of the dependencies into a collection of services
            IServiceCollection services = new ServiceCollection().AddIotaSDKServices();

            //Install services to service provider which is used for dependency injection
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //Use serviceprovider to create a scope, which disposes of all services at end of scope
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                //Request IWallet service from service provider
                IWallet wallet = scope.ServiceProvider.GetRequiredService<IWallet>();

                //Build wallet using a fluent-style configuration api
                wallet = await wallet
                                .ConfigureWalletOptions()
                                    .SetCoinType(TypeOfCoin.Shimmer)
                                    .SetStoragePath("./walletdb")
                                    .Then()
                                .ConfigureClientOptions()
                                    .AddNodeUrl("https://api.testnet.shimmer.network")
                                    .SetFaucetUrl("https://faucet.testnet.shimmer.network/api/enqueue")
                                    .IsLocalPow()
                                    .Then()
                                .ConfigureSecretManagerOptions()
                                    .SetPassword("password")
                                    .SetSnapshotPath("./mystronghold")
                                    .Then()
                                .InitializeAsync();


                //Let's proceed to retrieve our previously created "spending" account.
                IAccount spendingAccount = (await wallet.GetAccountAsync("spending")).Payload;

                //Let's sync our account to the Tangle
                var balance = await spendingAccount.SyncAcountAsync();

                //Let's get the nftId of the first nft that we created
                string nftId = balance.Payload.Nfts.First();

                //Sending to another wallet, eg bloom
                string receiverAddress = "rms1qrwp0umeexltwgmqh57jmag4c93qjgww4wnhk3ln5ylc6d2axnzfsy5kdya";
                AddressAndNftId addressAndNftId = new AddressAndNftId(receiverAddress, nftId);

                //Send the NFT
                await spendingAccount.SendNftsAsync(new List<AddressAndNftId> { addressAndNftId });
            }
        }
    }
}
