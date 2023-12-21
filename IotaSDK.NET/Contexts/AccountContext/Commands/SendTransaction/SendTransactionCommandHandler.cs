using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareTransaction;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendTransaction
{
    internal class SendTransactionCommandHandler : IRequestHandler<SendTransactionCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public SendTransactionCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(SendTransactionCommand request, CancellationToken cancellationToken)
        {
            var prepareTransactionResponse = await _mediator.Send(new PrepareTransactionCommand(request.WalletHandle, request.AccountIndex, request.Outputs, request.TransactionOptions));

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, prepareTransactionResponse.Payload));

        }
    }
}
