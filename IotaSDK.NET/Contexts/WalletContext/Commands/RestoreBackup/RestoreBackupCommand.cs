using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.RestoreBackup
{
    internal class RestoreBackupCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public RestoreBackupCommand(IntPtr walletHandle, string sourcePath, string password, bool ignoreIfCoinTypeMismatch = true, bool ignoreIfBech32Mismatch = true)
            : base(walletHandle)
        {
            SourcePath = sourcePath;
            Password = password;
            IgnoreIfCoinTypeMismatch = ignoreIfCoinTypeMismatch;
            IgnoreIfBech32Mismatch = ignoreIfBech32Mismatch;
        }

        public string SourcePath { get; }
        public string Password { get; }
        public bool IgnoreIfCoinTypeMismatch { get; }
        public bool IgnoreIfBech32Mismatch { get; }
    }
}
