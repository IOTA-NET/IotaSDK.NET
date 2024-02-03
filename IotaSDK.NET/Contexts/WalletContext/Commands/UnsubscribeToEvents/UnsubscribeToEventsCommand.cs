using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Events;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.UnsubscribeToEvents
{
    internal class UnsubscribeToEventsCommand : WalletRequest
    {
        public UnsubscribeToEventsCommand(IntPtr walletHandle, WalletEventType walletEventType) : base(walletHandle)
        {
            WalletEventType = walletEventType;
        }

        public WalletEventType WalletEventType { get; }
    }
}
