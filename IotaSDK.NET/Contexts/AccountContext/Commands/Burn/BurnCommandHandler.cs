using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.Burn
{
    internal class BurnCommandHandler : IRequestHandler<BurnCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public BurnCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(BurnCommand request, CancellationToken cancellationToken)
        {
            IotaSDKResponse<PreparedTransactionData> prepareBurnResponse =
                await _mediator.Send(new PrepareBurnCommand(request.WalletHandle, request.AccountIndex, request.BurnIds, request.TransactionOptions));

            PreparedTransactionData preparedTransactionData = prepareBurnResponse.Payload;

            IotaSDKResponse<Transaction> transactionResponse = await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));

            return transactionResponse;
        }
    }
}
