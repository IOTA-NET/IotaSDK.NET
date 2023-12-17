using IotaSDK.NET.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountIndexes
{
    internal class GetAccountIndexesQuery : WalletRequest<IotaSDKResponse<List<int>>>
    {
        public GetAccountIndexesQuery(IntPtr walletHandle)
            : base(walletHandle)
        {
        }
    }
}
