using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeToken;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.CreateNativeToken
{
    internal class CreateNativeTokenCommandHandler : IRequestHandler<CreateNativeTokenCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public CreateNativeTokenCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(CreateNativeTokenCommand request, CancellationToken cancellationToken)
        {
            var prepareCreateNativeTokenResponse = await _mediator.Send(new PrepareCreateNativeTokenCommand(request.WalletHandle, request.AccountIndex, request.NativeTokenCreationOptions, request.TransactionOptions));
            PreparedNativeTokenTransactionData preparedNativeTokenTransactionData = prepareCreateNativeTokenResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedNativeTokenTransactionData.PreparedTransactionData));
        }
    }
}
