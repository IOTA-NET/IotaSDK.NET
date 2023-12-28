using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyAlias;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.DestroyAlias
{
    internal class DestroyAliasCommandHandler : IRequestHandler<DestroyAliasCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public DestroyAliasCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(DestroyAliasCommand request, CancellationToken cancellationToken)
        {
            var preparedResponse = await _mediator.Send(new PrepareDestroyAliasCommand(request.WalletHandle, request.AccountIndex, request.AliasId, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = preparedResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
