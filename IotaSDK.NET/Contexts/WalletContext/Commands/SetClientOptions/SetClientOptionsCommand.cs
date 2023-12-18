using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetClientOptions
{
    internal class SetClientOptionsCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public SetClientOptionsCommand(ClientOptions clientOptions, IntPtr walletHandle) : base(walletHandle)
        {
            ClientOptions = clientOptions;
        }

        public ClientOptions ClientOptions { get; }
    }
}
