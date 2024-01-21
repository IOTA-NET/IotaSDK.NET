using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Events;
using System;
using static IotaSDK.NET.Common.Rust.RustBridgeWallet;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SubscribeToEvents
{
    internal class SubscribeToEventsCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public SubscribeToEventsCommand(IntPtr walletHandle, WalletEventType walletEventType, WalletEventHandler callback) : base(walletHandle)
        {
            WalletEventType = walletEventType;
            Callback = callback;
        }

        public WalletEventType WalletEventType { get; }
        public WalletEventHandler Callback { get; }
    }
}
