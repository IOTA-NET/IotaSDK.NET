using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyFoundry;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.DestroyFoundry
{
    internal class DestroyFoundryCommandHandler : IRequestHandler<DestroyFoundryCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public DestroyFoundryCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(DestroyFoundryCommand request, CancellationToken cancellationToken)
        {
            var preparedTransactionResponse = await _mediator.Send(new PrepareDestroyFoundryCommand(request.WalletHandle, request.AccountIndex, request.FoundryId, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = preparedTransactionResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
