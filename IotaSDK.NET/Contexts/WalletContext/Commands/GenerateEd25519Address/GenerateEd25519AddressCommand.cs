using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.Options;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.GenerateEd25519Address
{
    internal class GenerateEd25519AddressCommand : WalletRequest<IotaSDKResponse<string>>
    {
        public GenerateEd25519AddressCommand(IntPtr walletHandle, int accountIndex, int addressIndex, AddressGenerationOptions? addressGenerationOptions = null, HumanReadablePart? bech32Hrp = null)
            : base(walletHandle)
        {
            AccountIndex = accountIndex;
            AddressIndex = addressIndex;
            AddressGenerationOptions = addressGenerationOptions;
            Bech32Hrp = bech32Hrp.HasValue ? HumanReadablePartEnumConverter.Convert(bech32Hrp.Value) : null;
        }

        public int AccountIndex { get; }
        public int AddressIndex { get; }
        public AddressGenerationOptions? AddressGenerationOptions { get; }
        public string? Bech32Hrp { get; }
    }
}

