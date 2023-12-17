using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.Outputs
{
    public class Remainder
    {
        // The remainder output
        public Output Output { get; set; }

        // The chain derived from seed, for the remainder addresses
        public Bip44 Chain { get; set; }

        // The remainder address
        public Address Address { get; set; }

        // Constructor with default values
        public Remainder(Output output, Address address, Bip44 chain = null)
        {
            Output = output;
            Address = address;
            Chain = chain;
        }
    }

}
