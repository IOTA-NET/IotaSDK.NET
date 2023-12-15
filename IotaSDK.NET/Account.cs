using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.Sync;
using IotaSDK.NET.Contexts.AccountContext.Queries.GetAddresses;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
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

        public Account(IntPtr walletHandle, IMediator mediator,  int index, string username)
        {
            _walletHandle = walletHandle;
            _mediator = mediator;
            Index = index;
            Username = username;
        }

        public int Index { get; }
        public string Username { get; private set; }

        public async Task<IotaSDKResponse<List<AccountAddress>>> GetAddressesAsync()
        {
            return await _mediator.Send(new GetAddressesQuery(_walletHandle, Index));

        }

        public async Task SetAliasAsync(string alias)
        {
            await _mediator.Send(new SetAliasCommand(_walletHandle, Index, alias));
            Username = alias;
        }

        public async Task<IotaSDKResponse<AccountBalance>> SyncAcountAsync(SyncOptions? syncOptions=null)
        {
             return await _mediator.Send(new SyncCommand(_walletHandle, Index, syncOptions));

        }
    }
}
