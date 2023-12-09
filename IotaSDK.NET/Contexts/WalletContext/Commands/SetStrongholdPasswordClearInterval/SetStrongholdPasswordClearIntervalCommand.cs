using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetStrongholdPasswordClearInterval
{
    internal class SetStrongholdPasswordClearIntervalCommand : IRequest<IotaSDKResponse<bool>>
    {
        public SetStrongholdPasswordClearIntervalCommand(int intervalInMilliSeconds)
        {
            IntervalInMilliSeconds = intervalInMilliSeconds;
        }

        public int IntervalInMilliSeconds { get; }
    }

    internal class SetStrongholdPasswordClearIntervalCommandModelData
    {
        public SetStrongholdPasswordClearIntervalCommandModelData(int intervalInMilliseconds)
        {
            IntervalInMilliseconds = intervalInMilliseconds;
        }

        public int IntervalInMilliseconds { get; }
    }

    internal class SetStrongholdPasswordClearIntervalCommandHandler : IRequestHandler<SetStrongholdPasswordClearIntervalCommand, IotaSDKResponse<bool>>
    {
        public SetStrongholdPasswordClearIntervalCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            
        }
        public Task<IotaSDKResponse<bool>> Handle(SetStrongholdPasswordClearIntervalCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
