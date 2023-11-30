using IotaSDK.NET.Common.Interfaces;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHex
{
    internal class Bech32ToHexCommand : IRequest<IotaSDKResponse<string>>
    {
        public Bech32ToHexCommand(string bech32Address)
        {
            Bech32Address = bech32Address;
        }

        public string Bech32Address { get; }
    }
}
