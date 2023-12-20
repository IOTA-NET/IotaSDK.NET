using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IAccount
    {
        Task<IotaSDKResponse<AccountBalance>> SyncAcountAsync(SyncOptions? syncOptions = null);

        Task<IotaSDKResponse<AccountBalance>> GetBalanceAsync();

        Task<IotaSDKResponse<List<AccountAddress>>> GetAddressesAsync();

        Task SetAliasAsync(string alias);

        Task<IotaSDKResponse<Transaction>> SendBaseCoinAsync(ulong amount, string bech32ReceiverAddress, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<Transaction>> SignAndSubmitTransactionAsync(PreparedTransactionData transactionData);

        Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<List<OutputData>>> GetUnspentOutputsAsync(OutputFilterOptions? filterOptions = null);

        Task<IotaSDKResponse<OutputData>> GetOutputAsync(string outputId);

        Task<IotaSDKResponse<Transaction>> MintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNftAsync(string nftId, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<Transaction>> BurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null);

        Task<IotaSDKResponse<Transaction>> SendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null);

        Task SetDefaultSyncOptionsAsync(SyncOptions syncOptions);

        Task<IotaSDKResponse<List<Transaction>>> GetTransactionsAsync();

        Task<IotaSDKResponse<PreparedTransactionData>> PrepareConsolidateOutputsAsync(bool force, int? outputThreshold = null, string? targetAddress = null);

        Task<IotaSDKResponse<Transaction>> ConsolidateOutputsAsync(bool force, int? outputThreshold = null, string? targetAddress = null);

        Task<IotaSDKResponse<List<Transaction>>> GetPendingTransactionsAsync();

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
        Task<IotaSDKResponse<PreparedTransactionData>> PrepareTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions);
    }
}
