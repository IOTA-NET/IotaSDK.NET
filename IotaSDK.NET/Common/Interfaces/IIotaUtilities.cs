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
    }
}