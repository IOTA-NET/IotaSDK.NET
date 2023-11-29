using IotaSDK.NET.Common.Interfaces;
using MediatR;
using System;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic
{
    internal class VerifyMnemonicCommand : IRequest<IotaSDKResponse<bool>>
    {
        public VerifyMnemonicCommand(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public string Mnemonic { get; }
    }
}
