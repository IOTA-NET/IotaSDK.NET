using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System.Collections.Generic;
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
        /// Burn an nft output.
        /// </summary>
        /// <param name="nftId">The NftId.</param>
        /// <param name="transactionOptions">Additional transaction options or custom inputs.</param>
        /// <returns>The prepared transaction.</returns>
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNftAsync(string nftId, TransactionOptions? transactionOptions = null);

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
        Task<IotaSDKResponse<string>> RetryTransactionUntilIncludedAsync(string transactionId, int? interval, int? maxAttempts);

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
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions=null);

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
    }
}
