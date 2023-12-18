using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.Burn;
using IotaSDK.NET.Contexts.AccountContext.Commands.MintNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoin;
using IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.Sync;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetAddresses;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetBalance;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetUnspentOutputs;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET
{
    public class Account : IAccount
    {
        private readonly IntPtr _walletHandle;
        private readonly IMediator _mediator;

        public Account(IntPtr walletHandle, IMediator mediator, int index, string username)
        {
            _walletHandle = walletHandle;
            _mediator = mediator;
            Index = index;
            Username = username;
        }

        public int Index { get; }
        public string Username { get; private set; }

        public async Task<IotaSDKResponse<Transaction>> BurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new BurnCommand(_walletHandle, Index, burnIds, transactionOptions, _mediator));
        }

        public async Task<IotaSDKResponse<List<AccountAddress>>> GetAddressesAsync()
        {
            return await _mediator.Send(new GetAddressesQuery(_walletHandle, Index));

        }

        public async Task<IotaSDKResponse<AccountBalance>> GetBalanceAsync()
        {
            return await _mediator.Send(new GetBalanceQuery(_walletHandle, Index));
        }

        public async Task<IotaSDKResponse<OutputData>> GetOutputAsync(string outputId)
        {
            return await _mediator.Send(new GetOutputQuery(_walletHandle, Index, outputId));
        }

        public async Task<IotaSDKResponse<List<OutputData>>> GetUnspentOutputsAsync(OutputFilterOptions? filterOptions = null)
        {
            return await _mediator.Send(new GetUnspentOutputsQuery(_walletHandle, Index, filterOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> MintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new MintNftsCommand(_walletHandle, Index, nftOptionsList, transactionOptions, _mediator));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnAsync(BurnIds burnIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareBurnCommand(_walletHandle, Index, burnIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareBurnNftAsync(string nftId, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareBurnNftCommand(_walletHandle, Index, nftId, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareMintNftsAsync(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareMintNftsCommand(_walletHandle, Index, nftOptionsList, transactionOptions));
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> PrepareSendNftsAsync(List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new PrepareSendNftsCommand(_walletHandle, Index, addressAndNftIds, transactionOptions));
        }

        public async Task<IotaSDKResponse<Transaction>> SendBaseCoinAsync(ulong amount, string bech32ReceiverAddress, TransactionOptions? transactionOptions = null)
        {
            return await _mediator.Send(new SendBaseCoinCommand(_walletHandle, Index, amount, bech32ReceiverAddress, transactionOptions));
        }

        public async Task SetAliasAsync(string alias)
        {
            await _mediator.Send(new SetAliasCommand(_walletHandle, Index, alias));
            Username = alias;
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
