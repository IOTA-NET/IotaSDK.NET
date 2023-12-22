using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateAliasOutput;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.CreateAliasOutput
{
    internal class CreateAliasOutputCommandHandler : IRequestHandler<CreateAliasOutputCommand, IotaSDKResponse<Transaction>>
    {
        private readonly IMediator _mediator;

        public CreateAliasOutputCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(CreateAliasOutputCommand request, CancellationToken cancellationToken)
        {
            var prepareCreateAliasOutputResponse = await _mediator.Send(new PrepareCreateAliasOutputCommand(request.WalletHandle, request.AccountIndex, request.AliasOutputCreationOptions, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = prepareCreateAliasOutputResponse.Payload;

            return await _mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
