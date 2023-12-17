using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StoreMnemonic
{
    internal class StoreMnemonicCommand : WalletRequest
    {
        public StoreMnemonicCommand(IntPtr walletHandle, string mnemonic) : base(walletHandle)
        {
            Mnemonic = mnemonic;
        }
        public string Mnemonic { get; }
    }
}
