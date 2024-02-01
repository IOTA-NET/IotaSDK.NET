# Let's subscribe to some Wallet Events!
## Code Example

The following example will:

1. Create a wallet
2. Retrieve your spending account
3. Sync account
4. Subscribe to TransactionInclusion Event
5. Register a callback for the TransactionInclusion Event
6. Enable Background Syncing


```cs
public static class SubscribeToEventsExample
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


            //Let's proceed to retrieve our previously created"spending" account.
            IAccount spendingAccount = (await wallet.GetAccountAsync("spending")).Payload;
            await spendingAccount.SyncAcountAsync();

            /*
                * Available events are: ConsolidationRequired | NewOutput | SpentOutput | TransactionInclusion | TransactionProgress | LedgerAddressGeneration
                * Let's get automatically notified when our transaction succeeds. 
                * Hence we need to subscribe to TransactionInclusion event
                * */

            await wallet.SubscribeToEventsAsync(WalletEventType.TransactionInclusion);

            wallet.OnTransactionInclusion += Wallet_OnTransactionInclusion;

            //We put our wallet into periodic sync mode,
            //If it notices our tx getting confirmed, it would alert us
            await wallet.StartBackgroundSyncAsync(intervalInMilliseconds: 5000);

            //Lets send a tx to ourselves!
            string spendingAddress = (await spendingAccount.GetAddressesAsync()).Payload.First().Address;
            await spendingAccount.SendBaseCoinAsync(amount: 1000000, spendingAddress);

            //Just to not let program exit
            Console.ReadLine();

        }
    }
    private static void Wallet_OnTransactionInclusion(object? sender, WalletEventNotification e)
    {
        string transactionId = (e.Event as TransactionInclusionWalletEvent)!.TransactionId;
        Console.WriteLine($"Tx ID: {transactionId} just got confirmed!");
    }
}
```