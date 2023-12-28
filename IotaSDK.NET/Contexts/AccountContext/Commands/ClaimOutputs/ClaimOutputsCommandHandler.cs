using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareClaimOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.ClaimOutputs
{
    internal class ClaimOutputsCommandHandler : IRequestHandler<ClaimOutputsCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public ClaimOutputsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(ClaimOutputsCommand request, CancellationToken cancellationToken)
        {
            var prepareClaimOutputsResponse = await _mediator.Send(new PrepareClaimOutputsCommand(request.WalletHandle, request.AccountIndex, request.OutputIds));
            PreparedTransactionData preparedTransactionData = prepareClaimOutputsResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
