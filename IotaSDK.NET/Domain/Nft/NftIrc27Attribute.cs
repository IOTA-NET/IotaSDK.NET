namespace IotaSDK.NET.Domain.Nft
{
    public class NftIrc27Attribute
    {
        public NftIrc27Attribute(string traitType, string value)
        {
            TraitType = traitType;
            Value = value;
        }

        public string TraitType { get; set; }

        public string Value { get; set; }
    }
}
