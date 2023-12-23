using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetFoundryOutput
{
    internal class GetFoundryOutputQuery : AccountRequest<IotaSDKResponse<FoundryOutput>>
    {
        public GetFoundryOutputQuery(IntPtr walletHandle, int accountIndex, string tokenId) : base(walletHandle, accountIndex)
        {
            TokenId = tokenId;
        }

        public string TokenId { get; }
    }
}
