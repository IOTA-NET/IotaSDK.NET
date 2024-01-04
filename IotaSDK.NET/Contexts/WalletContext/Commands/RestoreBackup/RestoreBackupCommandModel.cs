namespace IotaSDK.NET.Contexts.WalletContext.Commands.RestoreBackup
{
    internal class RestoreBackupCommandModel
    {
        public RestoreBackupCommandModel(string source, string password, bool ignoreIfCoinTypeMismatch = true, bool ignoreIfBech32Mismatch = true)
        {
            Source = source;
            Password = password;
            IgnoreIfCoinTypeMismatch = ignoreIfCoinTypeMismatch;
            IgnoreIfBech32Mismatch = ignoreIfBech32Mismatch;
        }

        public string Source { get; }
        public string Password { get; }
        public bool IgnoreIfCoinTypeMismatch { get; }
        public bool IgnoreIfBech32Mismatch { get; }
    }
}
