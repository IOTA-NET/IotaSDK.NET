using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.CheckIfStrongholdPasswordExists
{
    internal class CheckIfStrongholdPasswordExistsQuery : WalletRequest<IotaSDKResponse<bool>>
    {

        public CheckIfStrongholdPasswordExistsQuery(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
