using IotaSDK.NET.Common.Interfaces;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed
{
    internal class MnemonicToHexSeedCommand : IRequest<IotaSDKResponse<string>>
    {
        public MnemonicToHexSeedCommand(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public string Mnemonic { get; }
    }
}
