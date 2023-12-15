using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias
{
    internal class SetAliasCommand : AccountRequest
    {
        public SetAliasCommand(IntPtr walletHandle, int accountIndex, string alias) : base(walletHandle, accountIndex)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
