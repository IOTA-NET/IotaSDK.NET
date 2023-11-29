using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic;
using IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed;
using MediatR;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext
{
    public class IotaUtilities : IIotaUtilities
    {
        private readonly IMediator _mediator;

        public IotaUtilities(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<string>> ConvertMnemonicToHexSeedAsync(string mnemonic)
        {
            return await _mediator.Send(new MnemonicToHexSeedCommand(mnemonic));
        }

        public async Task<IotaSDKResponse<string>> GenerateMnemonicAsync()
        {
            IotaSDKResponse<string> generateMnemonicResponse = await _mediator.Send(new GenerateMnemonicCommand());

            return generateMnemonicResponse;
        }
    }
}
