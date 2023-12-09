using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetStrongholdPasswordClearInterval
{
    internal class SetStrongholdPasswordClearIntervalCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public SetStrongholdPasswordClearIntervalCommand(IntPtr walletHandle, int intervalInMilliSeconds) : base(walletHandle)
        {
            IntervalInMilliSeconds = intervalInMilliSeconds;
        }

        public int IntervalInMilliSeconds { get; }
    }
}
