using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMeltNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MeltNativeTokens
{
    internal class MeltNativeTokensCommandHandler : IRequestHandler<MeltNativeTokensCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public MeltNativeTokensCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(MeltNativeTokensCommand request, CancellationToken cancellationToken)
        {
            var prepareMeltNativeTokensResponse = await _mediator.Send(new PrepareMeltNativeTokensCommand(request.WalletHandle, request.AccountIndex, request.TokenId, request.NumberOfTokensToMelt, request.TransactionOptions));
            PreparedTransactionData prepared = prepareMeltNativeTokensResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, prepared));
        }
    }
}
