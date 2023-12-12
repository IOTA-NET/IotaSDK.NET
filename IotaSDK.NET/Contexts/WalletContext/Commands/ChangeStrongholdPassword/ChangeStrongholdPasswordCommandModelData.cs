namespace IotaSDK.NET.Contexts.WalletContext.Commands.ChangeStrongholdPassword
{
    internal class ChangeStrongholdPasswordCommandModelData
    {
        public ChangeStrongholdPasswordCommandModelData(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

        public string CurrentPassword { get; }
        public string NewPassword { get; }
    }
}
