namespace IotaSDK.NET.Contexts.UtilsContext.Commands.AliasIdToBech32
{
    internal class AliasIdToBech32CommandModelData
    {
        public AliasIdToBech32CommandModelData(string aliasId, string bech32HumanReadablePart)
        {
            AliasId = aliasId;
            Bech32Hrp = bech32HumanReadablePart;
        }

        public string AliasId { get; }
        public string Bech32Hrp { get; }
    }
}
