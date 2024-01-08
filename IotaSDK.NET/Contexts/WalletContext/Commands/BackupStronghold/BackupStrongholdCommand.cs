using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.BackupStronghold
{
    internal class BackupStrongholdCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public BackupStrongholdCommand(IntPtr walletHandle, string destinationPath, string password) : base(walletHandle)
        {
            DestinationPath = destinationPath;
            Password = password;
        }

        public string DestinationPath { get; }
        public string Password { get; }
    }
}
