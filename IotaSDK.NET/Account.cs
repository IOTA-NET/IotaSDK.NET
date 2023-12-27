using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.Burn;
using IotaSDK.NET.Contexts.AccountContext.Commands.BurnNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.ConsolidateOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.CreateAliasOutput;
using IotaSDK.NET.Contexts.AccountContext.Commands.CreateNativeToken;
using IotaSDK.NET.Contexts.AccountContext.Commands.GenerateEd25519Addresses;
using IotaSDK.NET.Contexts.AccountContext.Commands.MintNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.MintNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareConsolidateOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateAliasOutput;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeToken;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.RetryTransactionUntilIncluded;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoin;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.SetDefaultSyncOptions;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.Sync;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetAddresses;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetAddressesWithUnspentOutputs;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetBalance;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetClaimableOutputs;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetFoundryOutput;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransaction;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransactions;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetOutputs;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetPendingTransactions;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetTransaction;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetTransactions;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetUnspentOutputs;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Faucet;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace IotaSDK.NET
{
    public class Account : IAccount
    {
        private readonly IntPtr _walletHandle;
        private readonly IWallet _wallet;
        private readonly IMediator _mediator;

        public Account(IntPtr walletHandle, IWallet wallet, IMediator mediator, int index, string username)
        {
            _walletHandle = walletHandle;
            _wallet = wallet;
            _mediator = mediator;
            Index = index;
            Username = username;
        }

        public int Index { get; }
        public string Username { get; private set; }

        public async Task<IotaSDKResponse<Transaction>> BurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new BurnCommand(_walletHandle, Index, burnIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> BurnNftAsync(string nftId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new BurnNftCommand(_walletHandle, Index, nftId, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> ConsolidateOutputsAsync(bool force, int? outputThreshold = null, string? targetAddress = null)
        {
            var consolidationOptions = new ConsolidationOptions(force) { OutputThreshold = outputThreshold, TargetAddress = targetAddress };
            return await _mediator.Send(new ConsolidateOutputsCommand(_walletHandle, Index, consolidationOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> CreateAliasOutputAsync(AliasOutputCreationOptions? aliasOutputCreationOptions = null, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new CreateAliasOutputCommand(_walletHandle, Index, aliasOutputCreationOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> CreateNativeTokenAsync(NativeTokenCreationOptions nativeTokenCreationOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new CreateNativeTokenCommand(_walletHandle, Index, nativeTokenCreationOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<List<AccountAddress>>> GenerateEd25519AddressesAsync(int numberOfAddresses, AddressGenerationOptions? addressGenerationOptions = null)
        {
            return await _mediator.Send(new GenerateEd25519AddressesCommand(_walletHandle, Index, numberOfAddresses, addressGenerationOptions));
        }

        public async Task<IotaSDKResponse<List<AccountAddress>>> GetAddressesAsync()
        {
            return await _mediator.Send(new GetAddressesQuery(_walletHandle, Index));

        }

        public async Task<IotaSDKResponse<List<AddressWithUnspentOutputs>>> GetAddressesWithUnspentOutputsAsync()
        {
            return await _mediator.Send(new GetAddressesWithUnspentOutputsQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<AccountBalance>> GetBalanceAsync()
        {
            return await _mediator.Send(new GetBalanceQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<List<string>>> GetClaimableOutputsAsync(ClaimableOutputType claimableOutputType)
        {
            return await _mediator.Send(new GetClaimableOutputsQuery(_walletHandle, Index, claimableOutputType));
        }

        public async Task<IotaSDKResponse<FoundryOutput>> GetFoundryOutputAsync(string tokenId)
        {
            return await _mediator.Send(new GetFoundryOutputQuery(_walletHandle, Index, tokenId));
        }

        public async Task<IotaSDKResponse<Transaction>> GetIncomingTransactionAsync(string transactionId)
        {
            return await _mediator.Send(new GetIncomingTransactionQuery(_walletHandle, Index, transactionId));
        }

        public async Task<IotaSDKResponse<List<Transaction>>> GetIncomingTransactionsAsync()
        {
            return await _mediator.Send(new GetIncomingTransactionsQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<OutputData>> GetOutputAsync(string outputId)
        {
            return await _mediator.Send(new GetOutputQuery(_walletHandle, Index, outputId));
        }

        public async Task<IotaSDKResponse<List<OutputData>>> GetOutputsAsync(OutputFilterOptions? outputFilterOptions)
        {
            return await _mediator.Send(new GetOutputsQuery(_walletHandle, Index, outputFilterOptions));
        }

        public async Task<IotaSDKResponse<List<Transaction>>> GetPendingTransactionsAsync()
        {
            return await _mediator.Send(new GetPendingTransactionsQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<Transaction>> GetTransactionAsync(string transactionId)
        {
            return await _mediator.Send(new GetTransactionQuery(_walletHandle, Index, transactionId));
        }

        public async Task<IotaSDKResponse<List<Transaction>>> GetTransactionsAsync()
        {
            return await _mediator.Send(new GetTransactionsQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<List<OutputData>>> GetUnspentOutputsAsync(OutputFilterOptions? filterOptions = null)
        {
            return await _mediator.Send(new GetUnspentOutputsQuery(_walletHandle, Index, filterOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> MintNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new MintNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToMint, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> MintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new MintNftsCommand(_walletHandle, Index, nftOptionsList, transactionOptions, _mediator));
        }

        public MintNftBuilder MintNftsUsingBuilder()
        {
            return new MintNftBuilder(this);
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareBurnCommand(_walletHandle, Index, burnIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNftAsync(string nftId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareBurnNftCommand(_walletHandle, Index, nftId, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareConsolidateOutputsAsync(bool force, int? outputThreshold = null, string? targetAddress = null)
        {
            ConsolidationOptions consolidationOptions = new ConsolidationOptions(force) { OutputThreshold = outputThreshold, TargetAddress = targetAddress };
            return await _mediator.Send(new PrepareConsolidateOutputsCommand(_walletHandle, Index, consolidationOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareCreateAliasOutputAsync(AliasOutputCreationOptions? aliasOutputCreationOptions = null, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareCreateAliasOutputCommand(_walletHandle, Index, aliasOutputCreationOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedNativeTokenTransactionData>> PrepareCreateNativeTokenAsync(NativeTokenCreationOptions nativeTokenCreationOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareCreateNativeTokenCommand(_walletHandle, Index, nativeTokenCreationOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareMintNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToMint, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareMintNftsCommand(_walletHandle, Index, nftOptionsList, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareSendNftsCommand(_walletHandle, Index, addressAndNftIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareTransactionCommand(_walletHandle, Index, outputs, transactionOptions));
        }

        public async Task<IotaSDKResponse<FaucetResponse>> RequestFundsFromFaucetAsync(string? bech32Address=null)
        {
            IClient client = _wallet.GetClient();
            return await _mediator.Send(new Contexts.AccountContext.Commands.RequestFundsFromFaucet.RequestFundsFromFaucetCommand(_walletHandle, Index, client, this, bech32Address));
        }

        public async Task<IotaSDKResponse<string>> RetryTransactionUntilIncludedAsync(string transactionId, int? interval = null, int? maxAttempts = null)
        {
            return await _mediator.Send(new RetryTransactionUntilIncludedCommand(_walletHandle, Index, transactionId, interval, maxAttempts));
        }

        public async Task<IotaSDKResponse<Transaction>> SendBaseCoinAsync(ulong amount, string bech32ReceiverAddress, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new SendBaseCoinCommand(_walletHandle, Index, amount, bech32ReceiverAddress, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> SendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new SendNftsCommand(_walletHandle, Index, addressAndNftIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> SendTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new SendTransactionCommand(_walletHandle, Index, outputs, transactionOptions));
        }

        public async Task SetAliasAsync(string alias)
        {
            await _mediator.Send(new SetAliasCommand(_walletHandle, Index, alias));
            Username = alias;
        }

        public async Task SetDefaultSyncOptionsAsync(SyncOptions syncOptions)
        {
            await _mediator.Send(new SetDefaultSyncOptionsCommand(_walletHandle, Index, syncOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> SignAndSubmitTransactionAsync(PreparedTransactionData transactionData)
        {
            return await _mediator.Send(new SignAndSubmitTransactionCommand(_walletHandle, Index, transactionData));
        }

        public async Task<IotaSDKResponse<AccountBalance>> SyncAcountAsync(SyncOptions? syncOptions = null)
        {
            return await _mediator.Send(new SyncCommand(_walletHandle, Index, syncOptions));

        }
    }
}
