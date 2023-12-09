namespace IotaSDK.NET.Domain.Addresses
{
    public class AccountAddress
    {
        public AccountAddress(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
        public int KeyIndex { get; set; }

        public bool Used { get; set; }
        public bool Internal { get; set; }
    }
}
