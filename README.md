# IotaSDK.NET
.NET Standard bindings to IOTA SDK


# Introduction :smile:

This project aims to port IOTA's official SDK, [Iota SDK](https://github.com/iotaledger/iota-sdk) to C# .NET, by leveraging its official native bindings, [Iota-SDK-native-bindings](https://github.com/iotaledger/iota-sdk-native-bindings).

Now .Net developers can have a chance trying out IOTA/Shimmer as well!


# Installation from Nuget.org

We have an alpha release of our nuget package [here](https://www.nuget.org/packages/IotaSDK/). Do let us know if there are any bugs!

To install,
> dotnet add package IotaSDK 


### Architecture support :grin:

- [x] Windows
- [x] Linux
- [ ] Mac (Soon)


# Examples :heart_eyes:
- Accounts and Addresses
  - [Create Wallet & Accounts](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Accounts%20and%20Addresses/Create%20Wallet%20and%20Account/README.md)
  - [Retrieve Account & Check Balance](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Accounts%20and%20Addresses/Check%20Balance/README.md)
  - [Generate Address](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Accounts%20and%20Addresses/Generate%20Addresses/README.md)
- Outputs and Transactions
  - [Request Funds from Faucet](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Outputs%20and%20Transactions/Request%20Tokens%20From%20Faucet/README.md)
  - [Send simple Basecoin Transaction](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Outputs%20and%20Transactions/Send%20a%20Basecoin%20Transaction/README.md)
- NFTs
  - [Mint Nfts](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Nfts/Mint%20an%20NFT/README.md)
  - [Send Nfts](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Nfts/Send%20an%20NFT/README.md)
  - [Burn Nfts](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Nfts/Burn%20an%20NFT/README.md)
- Native Tokens
  - [Creating a Foundry](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Native%20Tokens/Creating%20a%20Foundry/README.md)
  - [Sending Native Tokens](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Native%20Tokens/SendNativeTokens/README.md)
  - [Melt Native Tokens](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Native%20Tokens/Melt%20Native%20Tokens/README.md)
- Events
  - [Subscribe To Events](https://github.com/IOTA-NET/IotaSDK.NET/blob/main/IotaSDK.NET.Main/Examples/Events/Subscribe%20To%20Events/README.md)
    
# Supported bindings

## Wallet
<details>
  <summary> 
    Commands
  </summary>
  <ul>
	  <li>AuthenticateToStronghold</li>
    <li>BackupStronghold</li>
    <li>ChangeStrongholdPassword</li>
    <li>ClearStrongholdPassword</li>
    <li>CreateAccount</li>
    <li>DeleteLatestAccount</li>
    <li>GenerateEd25519Address</li>
	<li>RecoverAccounts</li>
	  <li>RestoreBackup</li>
    <li>SetClientOptions</li>
    <li>SetStrongholdPasswordClearInterval</li>
    <li>StartBackgroundSync</li>
    <li>StopBackgroundSync</li>
    <li>StoreMnemonic</li>
	<li>SubscribeToEvents</li>
	<li>UnsubscribeToEvents</li>
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
	<li>BurnNativeTokens</li>
    <li>BurnNft</li>
	<li>ClaimOutputs</li>
    <li>ConsolidateOutputs</li>
    <li>CreateAliasOutput</li>
    <li>CreateNativeToken</li>
	<li>DestroyAlias</li>
	<li>DestroyFoundry</li>
	<li>GenerateEd25519Addresses</li>
	<li>MeltNativeTokens</li>
	<li>MintNativeTokens</li>
    <li>MintNfts</li>
	<li>MintNftsUsingBuilder</li>
    <li>PrepareBurn</li>
	<li>PrepareBurnNativeTokens</li>
    <li>PrepareBurnNft</li>
	<li>PrepareClaimOutputs</li>
    <li>PrepareConsolidateOutputs</li>
    <li>PrepareCreateAliasOutput</li>
    <li>PrepareCreateNativeTokens</li>
	<li>PrepareDecreaseVotingPower</li>
	<li>PrepareDestroyAlias</li>
	<li>PrepareDestroyFoundry</li>
	<li>PrepareMeltNativeTokens</li>
	<li>PrepareMintNativeTokens</li>
    <li>PrepareMintNfts</li>
	<li>PrepareOutput</li>
	<li>PrepareSendBaseCoinToAddresses</li>
	<li>PrepareSendNativeTokens</li>
    <li>PrepareSendNfts</li>
	<li>PrepareStopParticipating</li>
    <li>PrepareTransactions</li>
	<li>PrepareVote</li>
	<li>RegisterParticipationEvents</li>
	<li>PrepareIncreaseVotingPower</li>
	<li>RequestFundsFromFaucet</li>
    <li>RetryTransactionUntilIncluded</li>
    <li>SendBaseCoin</li>
	<li>SendBaseCoinToAddresses</li>
	<li>SendNativeTokens</li>
	<li>SendNativeTokensUsingBuilder</li>
    <li>SendNfts</li>
    <li>SendTransaction</li>
    <li>SetAlias</li>
    <li>SetDefaultSyncOptions</li>
    <li>SignAndSubmitTransaction</li>
	<li>SignTransactionEssence</li>
	<li>SubmitSignedTransactionEssence</li>
    <li>Sync</li>
	<li>UnregisterParticipationEvent</li>
  </ul>
</details>

<details>
  <summary> 
    Queries
  </summary>
  <ul>
   <li>GetAddress</li>
   <li>GetAddressesWithUnspentOutputs</li>
   <li>GetBalance</li>
   <li>GetClaimableOutputs</li>
   <li>GetFoundryOutput</li>
   <li>GetIncomingTransaction</li>
   <li>GetIncomingTransactions</li>
   <li>GetOutput</li>
   <li>GetOutputs</li>
   <li>GetParticipationEvent</li>
   <li>GetParticipationEventIds</li>
   <li>GetParticipationEvents</li>
   <li>GetParticipationEventStatus</li>
   <li>GetParticipationOverview</li>
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

</details>

## SecretManager
TBD

