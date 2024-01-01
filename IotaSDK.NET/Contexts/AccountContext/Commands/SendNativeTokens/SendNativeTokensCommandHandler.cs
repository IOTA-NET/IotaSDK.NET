using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendNativeTokens
{
    internal class SendNativeTokensCommandHandler : IRequestHandler<SendNativeTokensCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public SendNativeTokensCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(SendNativeTokensCommand request, CancellationToken cancellationToken)
        {
            var preparedTransactionResponse = await _mediator.Send(new PrepareSendNativeTokensCommand(request.WalletHandle, request.AccountIndex, request.SendNativeTokensOptions, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = preparedTransactionResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
