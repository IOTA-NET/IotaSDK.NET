using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic;
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

        public Task<IotaSDKResponse<string>> ConvertMnemonicToHexSeedAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IotaSDKResponse<string>> GenerateMnemonicAsync()
        {
            IotaSDKResponse<string> generateMnemonicResponse = await _mediator.Send(new GenerateMnemonicCommand());

            return generateMnemonicResponse;
        }
    }
}
