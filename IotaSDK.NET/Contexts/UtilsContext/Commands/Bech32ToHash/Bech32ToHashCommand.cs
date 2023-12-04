using IotaSDK.NET.Common.Interfaces;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHash
{
    internal class Bech32ToHashCommand : IRequest<IotaSDKResponse<string>>
    {
        public Bech32ToHashCommand(string bech32Address)
        {
            Bech32Address = bech32Address;
        }

        public string Bech32Address { get; }
    }
}
