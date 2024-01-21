using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace IotaSDK.NET.Main.Examples.Native_Tokens.Creating_a_Foundry
{
    public static class GetFoundryImmutableMetadataExample
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

                //Let's get out Native Token's unique Id
                string tokenId = balance.Payload.NativeTokens.First().TokenId;

                //The foundry's immutable metadata is stored in the Foundry Output
                var foundryOutputFilter = new OutputFilterOptions() { FoundryIds = new List<string> { tokenId } };
                FoundryOutput? foundryOutput = (await spendingAccount.GetUnspentOutputsAsync(foundryOutputFilter)).Payload.First().Output as FoundryOutput;

                //We need to seek its immutable metadata feature
                string hexEncodedData  = (foundryOutput!.ImmutableFeatures!.First(x => x.GetFeatureType() == FeatureType.Metadata) as MetadataFeature)!.Data;
                string immutableMetadataJson = hexEncodedData.FromHexString();

                //Let's prettify it
                string formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(immutableMetadataJson), Formatting.Indented);

                Console.WriteLine(formattedJson);
            }
        }
    }
}
