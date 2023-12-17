namespace IotaSDK.NET.Contexts.WalletContext.Commands.CreateAccount
{
    internal class CreateAccountCommandModelData
    {
        public CreateAccountCommandModelData()
        {

        }

        public CreateAccountCommandModelData(string alias)
        {
            Alias = alias;
        }
        public string? Alias { get; set; }
    }
}
