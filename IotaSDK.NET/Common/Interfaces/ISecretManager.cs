using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Signatures;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface ISecretManager
    {
        Task<IotaSDKResponse<Signature>> SignStringDataAsync(string data, Bip44 chain);
    }
}