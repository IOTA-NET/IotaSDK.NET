using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Faucet;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RequestFundsFromFaucet
{
    internal class RequestFundsFromFaucetCommandHandler : IRequestHandler<RequestFundsFromFaucetCommand, IotaSDKResponse<FaucetResponse>>
    {

        public RequestFundsFromFaucetCommandHandler()
        {
        }
        public async Task<IotaSDKResponse<FaucetResponse>> Handle(RequestFundsFromFaucetCommand request, CancellationToken cancellationToken)
        {
            string? bech32Address = request.Bech32Address;
            
            if(bech32Address == null)
            {
                bech32Address = (await request.Account.GetAddressesAsync()).Payload.First().Address;
            }

            return await request.Client.RequestFundsFromFaucetAsync(bech32Address);

        }
    }
}
