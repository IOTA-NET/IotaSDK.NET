using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IIotaUtilities
    {
        Task<IotaSDKResponse<string>> GenerateMnemonicAsync();

        Task<IotaSDKResponse<string>> ConvertMnemonicToHexSeedAsync(string mnemonic);
        Task<IotaSDKResponse<bool>> VerifyMnemonicAsync(string mnemonic);

        Task<IotaSDKResponse<string>> ConvertNftIdToBech32Async(string nftId, HumanReadablePart humanReadablePart);

        Task<IotaSDKResponse<string>> ConvertBech32ToHashAsync(string bech32Address);

        Task<IotaSDKResponse<string>> ConvertAliasIdToBech32Async(string aliasId, HumanReadablePart humanReadablePart);

        Task<IotaSDKResponse<bool>> VerifyBech32Address(string bech32Address);

        Task<IotaSDKResponse<string>> ConvertPublicKeyToBech32Async(string hexEncodedPublicKey, HumanReadablePart humanReadablePart);

        Task<IotaSDKResponse<string>> ConvertHashToBech32Async(string hexEncodedHash, HumanReadablePart humanReadablePart);

        Task<IotaSDKResponse<string>> ConvertOutputIdToNftIdAsync(string hexEncodedOutputId);

        Task<IotaSDKResponse<ulong>> ComputeStorageDepositAsync(Output output, Rent rent);
    }
}