﻿using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed
{
    internal class MnemonicToHexSeedCommand : RustBridgeRequest<string>
    {
        public MnemonicToHexSeedCommand(string mnemonic, string rustMethodName) : base(rustMethodName)
        {
            Mnemonic = mnemonic;
        }

        public string Mnemonic { get; }
    }
}
