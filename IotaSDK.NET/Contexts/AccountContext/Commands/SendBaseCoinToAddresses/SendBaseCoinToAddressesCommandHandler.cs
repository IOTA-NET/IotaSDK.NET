using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendBaseCoinToAddresses;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoinToAddresses
{
    internal class SendBaseCoinToAddressesCommandHandler : IRequestHandler<SendBaseCoinToAddressesCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public SendBaseCoinToAddressesCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(SendBaseCoinToAddressesCommand request, CancellationToken cancellationToken)
        {
            var preparedTransactionResponse = await _mediator.Send(new PrepareSendBaseCoinToAddressesCommand(request.WalletHandle, request.AccountIndex, request.SendBaseCoinToAddressOptions, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = preparedTransactionResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
