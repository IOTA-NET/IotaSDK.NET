using MediatR;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.CheckIfStrongholdPasswordExists
{
    internal class CheckIfStrongholdPasswordExistsQuery : IRequest<bool>
    {

        public CheckIfStrongholdPasswordExistsQuery(IntPtr walletHandle)
        {
            WalletHandle = walletHandle;
        }

        public IntPtr WalletHandle { get; }
    }
}
