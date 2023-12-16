using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MintNft
{
    internal class MintNftCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public MintNftCommand(IntPtr walletHandle, int accountIndex) : base(walletHandle, accountIndex)
        {
        }
    }
}
