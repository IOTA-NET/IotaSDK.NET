namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyBech32Address
{
    internal class VerifyBech32AddressCommandModelData
    {
        public VerifyBech32AddressCommandModelData(string bech32Address)
        {
            Address = bech32Address;
        }

        public string Address { get; }
    }
}
