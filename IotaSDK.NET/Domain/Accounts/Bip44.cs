namespace IotaSDK.NET.Domain.Accounts
{
    public class Bip44
    {
        // The coin type segment.
        public int? CoinType { get; set; }

        // The account segment.
        public int? Account { get; set; }

        // The change segment.
        public int? Change { get; set; }

        // The address index segment.
        public int? AddressIndex { get; set; }

        // Constructor with default values
        public Bip44(int? coinType = null, int? account = null, int? change = null, int? addressIndex = null)
        {
            CoinType = coinType;
            Account = account;
            Change = change;
            AddressIndex = addressIndex;
        }
    }

}
