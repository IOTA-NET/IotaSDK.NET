using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.BurnNft
{
    internal class BurnNftCommandHandler : IRequestHandler<BurnNftCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public BurnNftCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(BurnNftCommand request, CancellationToken cancellationToken)
        {
            PreparedTransactionData preparedTransactionData =  (await _mediator.Send(new PrepareBurnNftCommand(request.WalletHandle, request.AccountIndex, request.NftId, request.TransactionOptions))).Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));

        }
    }
}
