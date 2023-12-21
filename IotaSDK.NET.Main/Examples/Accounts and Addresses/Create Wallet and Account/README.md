# Create a Wallet and an Account

## Code Example

The following example will:

1. Create an wallet
2. Create a Stronghold mnemonic
2. Use the wallet to store the Stronghold mnemonic into a stronghold file
3. Create 2 accounts with usernames `cookiemonster` and `elmo`

```cs
            //Register all of the dependencies into a collection of services
            IServiceCollection services = new ServiceCollection().AddIotaSDKServices();
            
            //Install services to service provider which is used for dependency injection
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            
            //Use serviceprovider to create a scope, which disposes of all services at end of scope
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
            //Request IIotaUtilities service from service provider
            IIotaUtilities iotaUtilities = scope.ServiceProvider.GetRequiredService<IIotaUtilities>();
            
            //Let's generate a new Mnemonic using IIotaUtilities
            var generateMnemonicResponse = await iotaUtilities.GenerateMnemonicAsync();
            string mnemonic = generateMnemonicResponse.Payload;
            
            Console.WriteLine($"The mnemonic we are going to use to create our wallet is:\n{mnemonic}");
            
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
            
            
            
            //Let's now store the mnemonic into stronghold
            //Stronghold is an open-source software library that was originally built to protect IOTA Seeds
            //https://wiki.iota.org/stronghold.rs/welcome/
            await wallet.StoreMnemonicAsync(mnemonic);
            
            //Let's proceed to create 2 accounts, with usernames "savings" and "spending"
            //Note: You can name them any names you want
            var accountResponse = await wallet.CreateAccountAsync(username: "savings");
            IAccount cookieMonsterAccount = accountResponse.Payload;
            
            accountResponse = await wallet.CreateAccountAsync(username: "spending");
            IAccount elmo = accountResponse.Payload;
            
            Console.WriteLine("Great, we have successfully created 2 accounts, our \"savings\" account and \"spending\" account");
```
