using IotaSDK.NET.Domain.Network;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IIotaUtilities
    {
        Task<IotaSDKResponse<string>> GenerateMnemonicAsync();

        Task<IotaSDKResponse<string>> ConvertMnemonicToHexSeedAsync(string mnemonic);
        Task<IotaSDKResponse<bool>> VerifyMnemonicAsync(string mnemonic);

        Task<IotaSDKResponse<string>> ConvertNftIdToBech32Async(string nftId, HumanReadablePart humanReadablePart);

        Task<IotaSDKResponse<string>> ConvertBech32ToHexStringAsync(string bech32Address);

        Task<IotaSDKResponse<string>> ConvertAliasIdToBech32Async(string aliasId, HumanReadablePart humanReadablePart);
    }
}