﻿using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.Burn;
using IotaSDK.NET.Contexts.AccountContext.Commands.BurnNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.BurnNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.ClaimOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.ConsolidateOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.CreateAliasOutput;
using IotaSDK.NET.Contexts.AccountContext.Commands.CreateNativeToken;
using IotaSDK.NET.Contexts.AccountContext.Commands.DestroyAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.DestroyFoundry;
using IotaSDK.NET.Contexts.AccountContext.Commands.GenerateEd25519Addresses;
using IotaSDK.NET.Contexts.AccountContext.Commands.MeltNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.MintNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.MintNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareClaimOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareConsolidateOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateAliasOutput;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDecreaseVotingPower;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyFoundry;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareIncreaseVotingPower;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMeltNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareOutput;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendBaseCoinToAddresses;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareStopParticipating;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareVote;
using IotaSDK.NET.Contexts.AccountContext.Commands.RegisterParticipationEvents;
using IotaSDK.NET.Contexts.AccountContext.Commands.RetryTransactionUntilIncluded;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoin;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoinToAddresses;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.SetDefaultSyncOptions;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignTransactionEssence;
using IotaSDK.NET.Contexts.AccountContext.Commands.SubmitSignedTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.Sync;
using IotaSDK.NET.Contexts.AccountContext.Commands.UnregisterParticipationEvent;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetAddresses;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetAddressesWithUnspentOutputs;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetBalance;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetClaimableOutputs;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetFoundryOutput;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransaction;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransactions;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetOutputs;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEvent;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventIds;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEvents;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventStatus;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationOverview;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetPendingTransactions;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetTransaction;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetTransactions;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetUnspentOutputs;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Faucet;
using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.PrepareOutput;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.ParticipationEvents;
using IotaSDK.NET.Domain.Signatures;
using IotaSDK.NET.Domain.Tokens;
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

        public async Task<IotaSDKResponse<Transaction>> BurnNativeTokensAsync(string tokenId, BigInteger numberOfTokensToBurn, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new BurnNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToBurn, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> BurnNftAsync(string nftId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new BurnNftCommand(_walletHandle, Index, nftId, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> ClaimOutputsAsync(List<string> outputIds)
        {
            return await _mediator.Send(new ClaimOutputsCommand(_walletHandle, Index, outputIds));
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

        public CreateNativeTokenBuilder CreateNativeTokensUsingBuilder()
        {
            return new CreateNativeTokenBuilder(this);
        }

        public async Task<IotaSDKResponse<Transaction>> DestroyAliasAsync(string aliasId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new DestroyAliasCommand(_walletHandle, Index, aliasId, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> DestroyFoundryAsync(string foundryId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new DestroyFoundryCommand(_walletHandle, Index, foundryId, transactionOptions));
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

        public async Task<IotaSDKResponse<ParticipationEventWithNodes>> GetParticipationEventAsync(string participationEventId)
        {
            return await _mediator.Send(new GetParticipationEventQuery(_walletHandle, Index, participationEventId));
        }

        public async Task<IotaSDKResponse<List<string>>> GetParticipationEventIdsAsync(Node node, ParticipationEventType? participationEventType = null)
        {
            return await _mediator.Send(new GetParticipationEventIdsQuery(_walletHandle, Index, node, participationEventType));
        }

        public async Task<IotaSDKResponse<ParticipationEventMap>> GetParticipationEventsAsync()
        {
            return await _mediator.Send(new GetParticipationEventsQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<ParticipationEventStatus>> GetParticipationEventStatusAsync(string eventId)
        {
            return await _mediator.Send(new GetParticipationEventStatusQuery(_walletHandle, Index, eventId));
        }

        public async Task<IotaSDKResponse<ParticipationOverview>> GetParticipationOverviewAsync(List<string>? participationEventIds = null)
        {
            return await _mediator.Send(new GetParticipationOverviewQuery(_walletHandle, Index, participationEventIds));
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

        public async Task<IotaSDKResponse<Transaction>> MeltNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMelt, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new MeltNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToMelt, transactionOptions));
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

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNativeTokensAsync(string tokenId, BigInteger numberOfTokensToBurn, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareBurnNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToBurn, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNftAsync(string nftId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareBurnNftCommand(_walletHandle, Index, nftId, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareClaimOutputsAsync(List<string> outputIds)
        {
            return await _mediator.Send(new PrepareClaimOutputsCommand(_walletHandle, Index, outputIds));
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
            return await _mediator.Send(new PrepareCreateNativeTokensCommand(_walletHandle, Index, nativeTokenCreationOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareDecreaseVotingPowerAsync(uint votingPower)
        {
            return await _mediator.Send(new PrepareDecreaseVotingPowerCommand(_walletHandle, Index, votingPower));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareDestroyAliasAsync(string aliasId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareDestroyAliasCommand(_walletHandle, Index, aliasId, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareDestroyFoundryAsync(string foundryId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareDestroyFoundryCommand(_walletHandle, Index, foundryId, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareIncreaseVotingPowerAsync(uint votingPower)
        {
            return await _mediator.Send(new PrepareIncreaseVotingPowerCommand(_walletHandle, Index, votingPower));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareMeltNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMelt, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareMeltNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToMelt, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNativeTokensAsync(string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareMintNativeTokensCommand(_walletHandle, Index, tokenId, numberOfTokensToMint, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareMintNftsCommand(_walletHandle, Index, nftOptionsList, transactionOptions));
        }

        public async Task<IotaSDKResponse<Output>> PrepareOutputAsync(PrepareOutputOptions prepareOutputOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareOutputCommand(_walletHandle, Index, prepareOutputOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendBaseCoinToAddressesAsync(List<SendBaseCoinToAddressOptions> sendBaseCoinToAddressOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareSendBaseCoinToAddressesCommand(_walletHandle, Index, sendBaseCoinToAddressOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNativeTokensAsync(List<SendNativeTokensOptions> sendNativeTokensOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareSendNativeTokensCommand(_walletHandle, Index, sendNativeTokensOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareSendNftsCommand(_walletHandle, Index, addressAndNftIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareStopParticipatingAsync(string participationEventId)
        {
            return await _mediator.Send(new PrepareStopParticipatingCommand(_walletHandle, Index, participationEventId));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareTransactionAsync(List<Output> outputs, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareTransactionCommand(_walletHandle, Index, outputs, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareVoteAsync(string? participationEventId = null, List<int>? answers = null)
        {
            return await _mediator.Send(new PrepareVoteCommand(_walletHandle, Index, participationEventId, answers));
        }

        public async Task<IotaSDKResponse<ParticipationEventMap>> RegisterParticipationEventsAsync(ParticipationEventRegistrationOptions participationEventRegistrationOptions)
        {
            return await _mediator.Send(new RegisterParticipationEventsCommand(_walletHandle, Index, participationEventRegistrationOptions));
        }

        public async Task<IotaSDKResponse<FaucetResponse>> RequestFundsFromFaucetAsync(string? bech32Address = null)
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

        public async Task<IotaSDKResponse<Transaction>> SendBaseCoinToAddressesAsync(List<SendBaseCoinToAddressOptions> sendBaseCoinToAddressOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new SendBaseCoinToAddressesCommand(_walletHandle, Index, sendBaseCoinToAddressOptions, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> SendNativeTokensAsync(List<SendNativeTokensOptions> sendNativeTokensOptions, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new SendNativeTokensCommand(_walletHandle, Index, sendNativeTokensOptions, transactionOptions));
        }

        public SendNativeTokensBuilder SendNativeTokensUsingBuilder()
        {
            return new SendNativeTokensBuilder(this);
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

        public async Task<IotaSDKResponse<SignedTransactionEssence>> SignTransactionEssenceAsync(PreparedTransactionData preparedTransactionData)
        {
            return await _mediator.Send(new SignTransactionEssenceCommand(_walletHandle, Index, preparedTransactionData));
        }

        public async Task<IotaSDKResponse<Transaction>> SubmitSignedTransactionAsync(SignedTransactionEssence signedTransactionEssence)
        {
            return await _mediator.Send(new SubmitSignedTransactionCommand(_walletHandle, Index, signedTransactionEssence));
        }

        public async Task<IotaSDKResponse<AccountBalance>> SyncAcountAsync(SyncOptions? syncOptions = null)
        {
            return await _mediator.Send(new SyncCommand(_walletHandle, Index, syncOptions));

        }

        public async Task UnregisterParticipationEventAsync(string participationEventId)
        {
            await _mediator.Send(new UnregisterParticipationEventCommand(_walletHandle, Index, participationEventId));
        }
    }
}
