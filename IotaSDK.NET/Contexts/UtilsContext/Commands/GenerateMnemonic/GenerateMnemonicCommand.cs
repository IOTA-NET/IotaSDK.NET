using IotaSDK.NET.Common.Interfaces;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic
{
    internal class GenerateMnemonicCommand : IRequest<IotaSDKResponse<string>>
    {
    }
}
