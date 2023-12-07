using MediatR;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StoreMnemonic
{
    internal class StoreMnemonicCommand : IRequest
    {
        public StoreMnemonicCommand(IntPtr walletHandle, string mnemonic)
        {
            WalletHandle = walletHandle;
            Mnemonic = mnemonic;
        }

        public IntPtr WalletHandle { get; }
        public string Mnemonic { get; }
    }
}
