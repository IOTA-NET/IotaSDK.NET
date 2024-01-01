using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.BurnNativeTokens
{
    internal class BurnNativeTokensCommandHandler : IRequestHandler<BurnNativeTokensCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public BurnNativeTokensCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(BurnNativeTokensCommand request, CancellationToken cancellationToken)
        {
            var preparedTransactionResponse = await _mediator.Send(new PrepareBurnNativeTokensCommand(request.WalletHandle, request.AccountIndex, request.TokenId, request.NumberOfTokensToBurn, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = preparedTransactionResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
