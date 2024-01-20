using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.GenerateEd25519Address
{
    internal class GenerateEd25519AddressCommandModelData
    {
        public GenerateEd25519AddressCommandModelData(int accountIndex, int addressIndex, AddressGenerationOptions? options, string? bech32Hrp)
        {
            AccountIndex = accountIndex;
            AddressIndex = addressIndex;
            Options = options;
            Bech32Hrp = bech32Hrp;
        }

        public int AccountIndex { get; }
        public int AddressIndex { get; }
        public AddressGenerationOptions? Options { get; }
        public string? Bech32Hrp { get; }
    }
}

