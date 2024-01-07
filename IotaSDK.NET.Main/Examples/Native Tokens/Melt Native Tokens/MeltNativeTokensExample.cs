using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main.Examples.Native_Tokens.SendNativeTokens
{
    public static class MeltNativeTokensExample
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
                var spendingBalance = await spendingAccount.SyncAcountAsync();

                //Let's get the tokenId of the Native Token "$CUTE" that we previously created.
                string tokenId = spendingBalance.Payload.NativeTokens.First().TokenId;

                //Let's get our foundry o
                var output = (await spendingAccount.GetUnspentOutputsAsync(new OutputFilterOptions() { FoundryIds = new List<string> { tokenId } })).Payload.First(); ;

                //Let's create a function which get more details of the foundry, particularly the number of tokens Minted/Melted and Max Supply.
                Func<Task> printFoundryInformationAsync = async () =>
                {
                    await spendingAccount.SyncAcountAsync();
                    OutputFilterOptions outputFilterOptions = new OutputFilterOptions()
                    {
                        FoundryIds = new List<string> { tokenId }
                    };
                    OutputData outputData = (await spendingAccount.GetUnspentOutputsAsync(outputFilterOptions)).Payload.First();

                    SimpleTokenScheme tokenScheme = (SimpleTokenScheme)((FoundryOutput)outputData.Output)!.TokenScheme;

                    Console.WriteLine($"Max Supply: {tokenScheme.MaximumSupply}\nMinted:{tokenScheme.MintedTokens}\nMelted:{tokenScheme.MeltedTokens}\n\n");
                };

                Console.WriteLine("Before:");
                await printFoundryInformationAsync();

                //Lets melt some tokens to remove them from the circulating supply
                Transaction meltTransaction = (await spendingAccount.MeltNativeTokensAsync(tokenId, numberOfTokensToMelt: 1000)).Payload;
                await spendingAccount.RetryTransactionUntilIncludedAsync(meltTransaction.TransactionId);

                Console.WriteLine("After:");
                await printFoundryInformationAsync();

            }
        }
    }

}
