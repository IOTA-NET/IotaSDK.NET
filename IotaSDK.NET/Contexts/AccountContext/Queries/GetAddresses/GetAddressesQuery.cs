using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Addresses;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetAddresses
{
    internal class GetAddressesQuery : AccountRequest<IotaSDKResponse<List<AccountAddress>>>
    {
        public GetAddressesQuery(IntPtr walletHandle, int accountIndex) : base(walletHandle, accountIndex)
        {
        }
    }
}
