using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Faucet;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.PrepareOutput;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Signatures;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// Sync the account by fetching new information from the nodes.
        /// Will also retry pending transactions if necessary.
        /// A custom default can be set using setDefaultSyncOptions.
        /// </summary>
        /// <param name="syncOptions">Optional synchronization options.</param>
        /// <returns>The account balance.</returns>
        Task<IotaSDKResponse<AccountBalance>> SyncAcountAsync(SyncOptions? syncOptions = null);

        /// <summary>
        /// Get the account balance.
        /// </summary>
        /// <returns>The account balance.</returns>
        Task<IotaSDKResponse<AccountBalance>> GetBalanceAsync();

        /// <summary>
        /// List all the addresses of the account.
        /// </summary>
        /// <returns>The addresses.</returns>
        Task<IotaSDKResponse<List<AccountAddress>>> GetAddressesAsync();

        /// <summary>
        /// Set the alias for the account
        /// </summary>
        /// <param name="alias">The account alias to set.</param>
        Task SetAliasAsync(string alias);

        /// <summary>
        /// Send base coins to an address.
        /// </summary>
        /// <param name="amount">Amount of coins.</param>
        /// <param name="bech32ReceiverAddress">Receiving address.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The sent transaction.</returns>
        Task<IotaSDKResponse<Transaction>> SendBaseCoinAsync(ulong amount, string bech32ReceiverAddress, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Sign a prepared transaction, and send it.
        /// </summary>
        /// <param name="transactionData">The prepared transaction data to sign and submit.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> SignAndSubmitTransactionAsync(PreparedTransactionData transactionData);

        /// <summary>
        /// Mint NFTs.
        /// </summary>
        /// <param name="nftOptionsList">The options for minting nfts.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared minting transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// List all the unspent outputs of the account.
        /// </summary>
        /// <param name="filterOptions">Options to filter the to be returned outputs.</param>
        /// <returns>The outputs with metadata.</returns>
        Task<IotaSDKResponse<List<OutputData>>> GetUnspentOutputsAsync(OutputFilterOptions? filterOptions = null);

        /// <summary>
        /// List all outputs of the account.
        /// </summary>
        /// <param name="outputId">Options to filter the to be returned outputs.</param>
        /// <returns>The outputs with metadata.</returns>
        Task<IotaSDKResponse<OutputData>> GetOutputAsync(string outputId);

        /// <summary>
        /// Mint NFTs.
        /// </summary>
        /// <param name="nftOptionsList">The options for minting nfts.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The minting transaction.   </returns>
        Task<IotaSDKResponse<Transaction>> MintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Users a fluent builder to mint Nfts
        /// </summary>
        /// <returns>A builder</returns>
        MintNftBuilder MintNftsUsingBuilder();

        // <summary>
        /// Users a fluent builder to create native tokens
        /// </summary>
        /// <returns>A builder</returns>
        CreateNativeTokenBuilder CreateNativeTokensUsingBuilder();

        /// <summary>
        /// Burn an nft output.
        /// </summary>
        /// <param name="nftId">The NftId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNftAsync(string nftId, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Burn an nft output.
        /// </summary>
        /// <param name="nftId">The NftId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The  transaction.</returns>
        Task<IotaSDKResponse<Transaction>> BurnNftAsync(string nftId, TransactionOptions? transactionOptions = null);
        /// <summary>
        /// A generic function that can be used to prepare to burn native tokens, nfts, foundries and aliases.
        /// </summary>
        /// <param name="burnIds">The outputs or native tokens to burn</param>
        /// <param name="transactionOptions">Additional transaction options</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// A generic function that can be used to prepare to burn native tokens, nfts, foundries and aliases.
        /// </summary>
        /// <param name="burnIds">The outputs or native tokens to burn</param>
        /// <param name="transactionOptions">Additional transaction options</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> BurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Send NFT.
        /// </summary>
        /// <param name="addressAndNftIds">Addresses and nft ids.</param>
        /// <param name="transactionOptions"> Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null);

        // <summary>
        /// Send NFT.
        /// </summary>
        /// <param name="addressAndNftIds">Addresses and nft ids.</param>
        /// <param name="transactionOptions"> Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> SendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Set the fallback SyncOptions for account syncing.
        /// If storage is enabled, will persist during restarts.
        /// </summary>
        /// <param name="syncOptions">The sync options to set.</param>
        Task SetDefaultSyncOptionsAsync(SyncOptions syncOptions);

        /// <summary>
        /// List all the transactions of the account.
        /// </summary>
        /// <returns>The transactions.</returns>
        Task<IotaSDKResponse<List<Transaction>>> GetTransactionsAsync();

        /// <summary>
        /// Consolidate basic outputs with only an `AddressUnlockCondition` from an account
        /// by sending them to an own address again if the output amount is greater or
        /// equal to the output consolidation threshold.
        /// </summary>
        /// <param name="force">Ignores the output threshold if set to `true`</param>
        /// <param name="outputThreshold">Consolidates if the output number is >= the output_threshold.</param>
        /// <param name="targetAddress">Address to which the consolidated output should be sent.</param>
        /// <returns>The prepared consolidation transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareConsolidateOutputsAsync(bool force, int? outputThreshold = null, string? targetAddress = null);

        /// <summary>
        /// Consolidate basic outputs with only an `AddressUnlockCondition` from an account
        /// by sending them to an own address again if the output amount is greater or
        /// equal to the output consolidation threshold.
        /// </summary>
        /// <param name="force">Ignores the output threshold if set to `true`</param>
        /// <param name="outputThreshold">Consolidates if the output number is >= the output_threshold.</param>
        /// <param name="targetAddress">Address to which the consolidated output should be sent.</param>
        /// <returns>The consolidation transaction.</returns>
        Task<IotaSDKResponse<Transaction>> ConsolidateOutputsAsync(bool force, int? outputThreshold = null, string? targetAddress = null);

        /// <summary>
        /// List all the pending transactions of the account.
        /// </summary>
        /// <returns>The transactions.</returns>
        Task<IotaSDKResponse<List<Transaction>>> GetPendingTransactionsAsync();

        /// <summary>
        /// Retries (promotes or reattaches) a transaction sent from the account for a provided transaction id until it's
        /// included (referenced by a milestone). Returns the included block id.
        /// </summary>
        /// <param name="transactionId">The id of the transaction to retry.</param>
        /// <param name="interval">The interval in seconds, defaults to 1 second</param>
        /// <param name="maxAttempts">Maximum number of retry attempts, defaults to 40</param>
        Task<IotaSDKResponse<string>> RetryTransactionUntilIncludedAsync(string transactionId, int? interval = null, int? maxAttempts = null);

        /// <summary>
        /// List all incoming transactions of the account.
        /// </summary>
        /// <returns>The incoming transactions with their inputs.</returns>
        Task<IotaSDKResponse<List<Transaction>>> GetIncomingTransactionsAsync();

        /// <summary>
        /// Get outputs with additional unlock conditions.
        /// </summary>
        /// <param name="claimableOutputType">The type of outputs to claim.</param>
        /// <returns>The output IDs of the unlockable outputs.</returns>
        Task<IotaSDKResponse<List<string>>> GetClaimableOutputsAsync(ClaimableOutputType claimableOutputType);

        /// <summary>
        /// Prepare a transaction, useful for offline signing.
        /// </summary>
        /// <param name="outputs">Outputs to use in the transaction.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction data.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Get a transaction stored in the account.
        /// </summary>
        /// <param name="transactionId">transactionId The ID of the transaction to get.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> GetTransactionAsync(string transactionId);

        /// <summary>
        /// Send a transaction.
        /// </summary>
        /// <param name="outputs">Outputs to use in the transaction.</param>
        /// <param name="transactionOptions">Additional transaction options</param>
        /// <returns>The transaction data.</returns>
        Task<IotaSDKResponse<Transaction>> SendTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// List all outputs of the account.
        /// </summary>
        /// <param name="outputFilterOptions">Options to filter the to be returned outputs.</param>
        /// <returns>The outputs with metadata.</returns>
        Task<IotaSDKResponse<List<OutputData>>> GetOutputsAsync(OutputFilterOptions? outputFilterOptions);

        /// <summary>
        /// Create a native token.
        /// </summary>
        /// <param name="nativeTokenCreationOptions">The options for creating a native token.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The created transaction and the token ID.</returns>
        Task<IotaSDKResponse<PreparedNativeTokenTransactionData>> PrepareCreateNativeTokenAsync(NativeTokenCreationOptions nativeTokenCreationOptions, TransactionOptions? transactionOptions = null);


        /// <summary>
        /// Create a native token.
        /// </summary>
        /// <param name="nativeTokenCreationOptions">The options for creating a native token.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The created transaction</returns>
        Task<IotaSDKResponse<Transaction>> CreateNativeTokenAsync(NativeTokenCreationOptions nativeTokenCreationOptions, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Creates an alias output
        /// </summary>
        /// <param name="aliasOutputCreationOptions">The alias output options.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareCreateAliasOutputAsync(AliasOutputCreationOptions? aliasOutputCreationOptions = null, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Creates an alias output
        /// </summary>
        /// <param name="aliasOutputCreationOptions">The alias output options.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> CreateAliasOutputAsync(AliasOutputCreationOptions? aliasOutputCreationOptions = null, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Get a `FoundryOutput` by native token ID. It will try to get the foundry from
        /// the account, if it isn't in the account it will try to get it from the node.
        /// </summary>
        /// <param name="tokenId">The native token ID to get the foundry for.</param>
        /// <returns>The `FoundryOutput` that minted the token.</returns>
        Task<IotaSDKResponse<FoundryOutput>> GetFoundryOutputAsync(string tokenId);

        /// <summary>
        /// Get the transaction with inputs of an incoming transaction stored in the account
        /// List might not be complete, if the node pruned the data already
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to get.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> GetIncomingTransactionAsync(string transactionId);

        /// <summary>
        /// Request funds from a faucet.
        /// </summary>
        /// <param name="bech32Address">The address to send the funds to.</param>
        /// <returns>The faucet response.</returns>
        Task<IotaSDKResponse<FaucetResponse>> RequestFundsFromFaucetAsync(string? bech32Address = null);

        /// <summary>
        /// Generate new unused Ed25519 addresses.
        /// </summary>
        /// <param name="numberOfAddresses">The amount of addresses to generate.</param>
        /// <param name="addressGenerationOptions">Options for address generation.</param>
        /// <returns>The addresses.</returns>
        Task<IotaSDKResponse<List<AccountAddress>>> GenerateEd25519AddressesAsync(int numberOfAddresses, AddressGenerationOptions? addressGenerationOptions = null);


        /// <summary>
        /// List the addresses of the account with unspent outputs.
        /// </summary>
        /// <returns>The addresses.</returns>
        Task<IotaSDKResponse<List<AddressWithUnspentOutputs>>> GetAddressesWithUnspentOutputsAsync();

        /// <summary>
        /// Mint additional native tokens.
        /// </summary>
        /// <param name="tokenId">The native token id.</param>
        /// <param name="numberOfTokensToMint">To be minted amount.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared minting transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Mint additional native tokens.
        /// </summary>
        /// <param name="tokenId">The native token id.</param>
        /// <param name="numberOfTokensToMint">To be minted amount.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The minting transaction.</returns>
        Task<IotaSDKResponse<Transaction>> MintNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Sign a prepared transaction, useful for offline signing.
        /// </summary>
        /// <param name="preparedTransactionData">The prepared transaction data to sign.</param>
        /// <returns>The signed transaction essence.</returns>
        Task<IotaSDKResponse<SignedTransactionEssence>> SignTransactionEssenceAsync(PreparedTransactionData preparedTransactionData);

        /// <summary>
        /// Claim basic or nft outputs that have additional unlock conditions
        /// to their `AddressUnlockCondition` from the account.
        /// </summary>
        /// <param name="outputIds">The outputs to claim.</param>
        /// <returns>The prepared transaction</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareClaimOutputsAsync(List<string> outputIds);

        /// <summary>
        /// Claim basic or nft outputs that have additional unlock conditions
        /// to their `AddressUnlockCondition` from the account.
        /// </summary>
        /// <param name="outputIds">The outputs to claim.</param>
        /// <returns>The transaction</returns>
        Task<IotaSDKResponse<Transaction>> ClaimOutputsAsync(List<string> outputIds);

        /// <summary>
        /// Melt native tokens. This happens with the foundry output which minted them, by increasing its
        /// `melted_tokens` field.
        /// </summary>
        /// <param name="tokenId">The native token id.</param>
        /// <param name="numberOfTokensToMelt">To be melted amount.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareMeltNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMelt, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Melt native tokens. This happens with the foundry output which minted them, by increasing its
        /// `melted_tokens` field.
        /// </summary>
        /// <param name="tokenId">The native token id.</param>
        /// <param name="numberOfTokensToMelt">To be melted amount.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> MeltNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMelt, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Validate the transaction, submit it to a node and store it in the account.
        /// </summary>
        /// <param name="signedTransactionEssence">A signed transaction to submit and store.</param>
        /// <returns>The sent transaction.</returns>
        Task<IotaSDKResponse<Transaction>> SubmitSignedTransactionAsync(SignedTransactionEssence signedTransactionEssence);

        /// <summary>
        /// Destroy an alias output.
        /// </summary>
        /// <param name="aliasId">The AliasId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareDestroyAliasAsync(string aliasId, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Destroy an alias output.
        /// </summary>
        /// <param name="aliasId">The AliasId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> DestroyAliasAsync(string aliasId, TransactionOptions? transactionOptions = null);


        /// <summary>
        /// Prepare to send base coins, useful for offline signing.
        /// </summary>
        /// <param name="sendBaseCoinToAddressOptions">Address with amounts to send.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction data.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendBaseCoinToAddressesAsync(List<SendBaseCoinToAddressOptions> sendBaseCoinToAddressOptions, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Send base coins with amounts from input addresses.
        /// </summary>
        /// <param name="sendBaseCoinToAddressOptions">Address with amounts to send.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction data.</returns>
        Task<IotaSDKResponse<Transaction>> SendBaseCoinToAddressesAsync(List<SendBaseCoinToAddressOptions> sendBaseCoinToAddressOptions, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Prepare an output for sending, useful for offline signing.
        /// </summary>
        /// <param name="prepareOutputOptions">
        /// The options for preparing an output.
        /// If the amount is below the minimum required storage deposit, by default the remaining
        /// amount will automatically be added with a `StorageDepositReturn` `UnlockCondition`.
        /// When setting the `ReturnStrategy` to `gift`, the full minimum required
        /// storage deposit will be sent to the recipient.
        /// When the assets contain an nft id, the data from the existing `NftOutput` will be used, just with
        /// the address unlock conditions replaced.
        /// </param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared output.</returns>
        Task<IotaSDKResponse<Output>> PrepareOutputAsync(PrepareOutputOptions prepareOutputOptions, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Send native tokens.
        /// </summary>
        /// <param name="sendNativeTokensOptions">Addresses amounts and native tokens.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNativeTokensAsync(List<SendNativeTokensOptions> sendNativeTokensOptions, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Send native tokens.
        /// </summary>
        /// <param name="sendNativeTokensOptions">Addresses amounts and native tokens.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> SendNativeTokensAsync(List<SendNativeTokensOptions> sendNativeTokensOptions, TransactionOptions? transactionOptions = null);

        SendNativeTokensBuilder SendNativeTokensUsingBuilder();

        /// <summary>
        /// Function to destroy a foundry output with a circulating supply of 0.
        /// Native tokens in the foundry (minted by other foundries) will be transacted to the controlling alias.
        /// </summary>
        /// <param name="foundryId">The FoundryId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareDestroyFoundryAsync(string foundryId, TransactionOptions? transactionOptions = null);


        /// <summary>
        /// Function to destroy a foundry output with a circulating supply of 0.
        /// Native tokens in the foundry (minted by other foundries) will be transacted to the controlling alias.
        /// </summary>
        /// <param name="foundryId">The FoundryId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> DestroyFoundryAsync(string foundryId, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Burn native tokens. This doesn't require the foundry output which minted them, but will not increase
        /// the foundries `melted_tokens` field, which makes it impossible to destroy the foundry output. Therefore it's
        /// recommended to use melting, if the foundry output is available.
        /// </summary>
        /// <param name="tokenId">The native token id</param>
        /// <param name="numberOfTokensToBurn">The to be burned amount.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNativeTokensAsync(string tokenId, BigInteger numberOfTokensToBurn, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Burn native tokens. This doesn't require the foundry output which minted them, but will not increase
        /// the foundries `melted_tokens` field, which makes it impossible to destroy the foundry output. Therefore it's
        /// recommended to use melting, if the foundry output is available.
        /// </summary>
        /// <param name="tokenId">The native token id</param>
        /// <param name="numberOfTokensToBurn">The to be burned amount.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The transaction.</returns>
        Task<IotaSDKResponse<Transaction>> BurnNativeTokensAsync(string tokenId, BigInteger numberOfTokensToBurn, TransactionOptions? transactionOptions = null);

        /// <summary>
        /// Prepare a vote.
        /// </summary>
        /// <param name="participationEventId">The participation event ID.</param>
        /// <param name="answers">Answers for a voting event, can be empty.</param>
        /// <returns>An instance of `PreparedTransaction`.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareVoteAsync(string? participationEventId = null, List<int>? answers = null);

        /// <summary>
        /// Prepare to increase the voting power.
        /// </summary>
        /// <param name="votingPower">The amount to increase the voting power by.</param>
        /// <returns>An instance of `PreparedTransaction`.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareIncreaseVotingPowerAsync(uint votingPower);

        /// <summary>
        /// Prepare to decrease the voting power.
        /// </summary>
        /// <param name="votingPower">The amount to increase the voting power by.</param>
        /// <returns>An instance of `PreparedTransaction`.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareDecreaseVotingPowerAsync(uint votingPower);
    }
}
