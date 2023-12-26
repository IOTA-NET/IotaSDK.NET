using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Addresses;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetAddressesWithUnspentOutputs
{
    internal class GetAddressesWithUnspentOutputsQuery : AccountRequest<IotaSDKResponse<List<AddressWithUnspentOutputs>>>
    {
        public GetAddressesWithUnspentOutputsQuery(IntPtr walletHandle, int accountIndex) : base(walletHandle, accountIndex)
        {
        }
    }
}
