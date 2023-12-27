using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNativeTokens;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MintNativeTokens
{
    internal class MintNativeTokensCommandHandler : IRequestHandler<MintNativeTokensCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public MintNativeTokensCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(MintNativeTokensCommand request, CancellationToken cancellationToken)
        {
            var prepareMintNativeTokensResponse = await _mediator.Send(new PrepareMintNativeTokensCommand(request.WalletHandle, request.AccountIndex, request.TokenId, request.NumberOfTokensToMint, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = prepareMintNativeTokensResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
