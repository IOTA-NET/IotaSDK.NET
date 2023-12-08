using IotaSDK.NET.Common.Interfaces;
using MediatR;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.CheckIfStrongholdPasswordExists
{
    internal class CheckIfStrongholdPasswordExistsQuery : IRequest<IotaSDKResponse<bool>>
    {

        public CheckIfStrongholdPasswordExistsQuery(IntPtr walletHandle)
        {
            WalletHandle = walletHandle;
        }

        public IntPtr WalletHandle { get; }
    }
}
