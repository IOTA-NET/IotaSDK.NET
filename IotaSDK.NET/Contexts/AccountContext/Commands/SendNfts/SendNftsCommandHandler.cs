using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendNfts
{
    internal class SendNftsCommandHandler : IRequestHandler<SendNftsCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public SendNftsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(SendNftsCommand request, CancellationToken cancellationToken)
        {
            var prepareSendNftsResponse = await _mediator.Send(new PrepareSendNftsCommand(request.WalletHandle, request.AccountIndex, request.AddressAndNftIds, request.TransactionOptions));
            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, prepareSendNftsResponse.Payload));

        }
    }
}
