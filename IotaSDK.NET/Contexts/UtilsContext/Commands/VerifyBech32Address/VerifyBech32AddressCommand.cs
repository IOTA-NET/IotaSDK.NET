using IotaSDK.NET.Common.Interfaces;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyBech32Address
{
    internal class VerifyBech32AddressCommand : IRequest<IotaSDKResponse<bool>>
    {
        public VerifyBech32AddressCommand(string bech32Address)
        {
            Bech32Address = bech32Address;
        }

        public string Bech32Address { get; }
    }
}
