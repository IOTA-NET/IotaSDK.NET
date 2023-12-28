using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Options;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.GenerateEd25519Addresses
{
    internal class GenerateEd25519AddressesCommand : AccountRequest<IotaSDKResponse<List<AccountAddress>>>
    {
        public GenerateEd25519AddressesCommand(IntPtr walletHandle, int accountIndex, int numberOfAddresses, AddressGenerationOptions? addressGenerationOptions = null) : base(walletHandle, accountIndex)
        {
            NumberOfAddresses = numberOfAddresses;
            AddressGenerationOptions = addressGenerationOptions;
        }

        public int NumberOfAddresses { get; }
        public AddressGenerationOptions? AddressGenerationOptions { get; }
    }
}
