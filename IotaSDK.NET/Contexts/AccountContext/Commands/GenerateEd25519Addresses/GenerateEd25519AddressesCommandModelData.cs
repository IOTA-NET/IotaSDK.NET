using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.GenerateEd25519Addresses
{
    internal class GenerateEd25519AddressesCommandModelData
    {
        public GenerateEd25519AddressesCommandModelData(int amount, AddressGenerationOptions? options)
        {
            Amount = amount;
            Options = options;
        }

        public int Amount { get; }
        public AddressGenerationOptions? Options { get; }
    }

}
