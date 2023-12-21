# IotaSDK.NET
.NET Standard bindings to IOTA SDK


# Introduction :smile:

This project aims to port IOTA's official SDK, [Iota SDK](https://github.com/iotaledger/iota-sdk) to C# .NET, by leveraging its official native bindings, [Iota-SDK-native-bindings](https://github.com/iotaledger/iota-sdk-native-bindings).

Now .Net developers can have a chance trying out IOTA/Shimmer as well!


# Installation from Nuget.org

We have yet to publish the package as it is still in development.


### Architecture support :grin:

- [x] Windows
- [x] Linux
- [x] Mac


# Examples :heart_eyes:
- Accounts and Addresses
  - [Create Wallet & Accounts](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Accounts%20and%20Addresses/Create%20Wallet%20and%20Account/README.md)

# Supported bindings

## Wallet
<details>
  <summary> 
    Commands
  </summary>
  <ul>
    <li>AuthenticateToStronghold</li>
    <li>ChangeStrongholdPassword</li>
    <li>ClearStrongholdPassword</li>
    <li>CreateAccount</li>
    <li>DeleteLastAccount</li>
    <li>SetClientOptions</li>
    <li>SetStrongholdPasswordClearInterval</li>
    <li>StartBackgroundSync</li>
    <li>StopBackgroundSync</li>
    <li>StoreMnemonic</li>
  </ul>
</details>

<details>
  <summary> 
    Queries
  </summary>
  <ul>
    <li>CheckIfStrongholdPasswordExists</li>
    <li>GetAccountIndexes</li>
    <li>GetAccounts</li>
    <li>GetAccountWithAlias</li>
    <li>GetAccountWithIndex</li>
  </ul>
</details>

## Account
<details>
  <summary> 
    Commands
  </summary>
  <ul>
    <li>Burn</li>
    <li>ConsolidateOutputs</li>
    <li>MintNfts</li>
    <li>PrepareBurn</li>
    <li>PrepareBurnNft</li>
    <li>PrepareConsolidateOutputs</li>
    <li>PrepareMintNfts</li>
    <li>PrepareSendNfts</li>
    <li>PrepareTransactions</li>
    <li>RetryTransactionUntilIncluded</li>
    <li>SendBaseCoin</li>
    <li>SendNfts</li>
    <li>SendTransaction</li>
    <li>SetAlias</li>
    <li>SetDefaultSyncOptions</li>
    <li>SignAndSubmitTransaction</li>
    <li>Sync</li>
  </ul>
</details>

<details>
  <summary> 
    Queries
  </summary>
  <ul>
   <li>GetAddress</li>
   <li>GetBalance</li>
   <li>GetClaimableOutputs</li>
   <li>GetIncomingTransactions</li>
   <li>GetOutput</li>
   <li>GetOutputs</li>
   <li>GetPendingTransactions</li>
   <li>GetTransaction</li>
   <li>GetTransactions</li>
   <li>GetUnspentOutputs</li>
  </ul>
</details>

## Client
<details>
  <summary> 
    Commands
  </summary>
  <ul>
   <li>RequestFundsFromFaucet</li>
  </ul>
</details>

<details>
  <summary> 
    Queries
  </summary>
  <ul>
  
  </ul>
</details>

## Utilities
<details>
  <summary> 
    Commands
  </summary>
  <ul>
   <li>AliasIdToBech32</li>
   <li>Bech32ToHash</li>
   <li>ComputeStorageDeposit</li>
   <li>GenerateMnemonic</li>
   <li>HashToBech32</li>
   <li>MnemonicToHexSeed</li>
   <li>NftIdToBech32</li>
   <li>OutputIdToNftId</li>
   <li>PublicKeyToBech32</li>
   <li>StartLogger</li>
   <li>VerifyBech32Address</li>
   <li>VerifyMnemonic</li>
  </ul>
</details>

<details>
  <summary> 
    Queries
  </summary>
  <ul>
  
  </ul>

## SecretManager
TBD

</details>
