using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareConsolidateOutputs;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.ConsolidateOutputs
{
    internal class ConsolidateOutputsCommandHandler : IRequestHandler<ConsolidateOutputsCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public ConsolidateOutputsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(ConsolidateOutputsCommand request, CancellationToken cancellationToken)
        {
            var prepareConsolidateOutputCommand = new PrepareConsolidateOutputsCommand(request.WalletHandle, request.AccountIndex, request.ConsolidationOptions);
            var prepareConsolidateOutputsResponse = await _mediator.Send(prepareConsolidateOutputCommand);
            var preparedTransaction = prepareConsolidateOutputsResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransaction));
        }
    }
}
