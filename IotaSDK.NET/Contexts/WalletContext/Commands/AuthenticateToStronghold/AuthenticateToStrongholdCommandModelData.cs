namespace IotaSDK.NET.Contexts.WalletContext.Commands.AuthenticateToStronghold
{
    internal class AuthenticateToStrongholdCommandModelData
    {
        public AuthenticateToStrongholdCommandModelData(string password)
        {
            Password = password;
        }
        public string Password { get; }
    }
}
