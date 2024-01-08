namespace IotaSDK.NET.Contexts.WalletContext.Commands.BackupStronghold
{
    internal class BackupStrongholdCommandModelData
    {
        public BackupStrongholdCommandModelData(string destination, string password)
        {
            Destination = destination;
            Password = password;
        }

        public string Destination { get; }
        public string Password { get; }
    }
}
