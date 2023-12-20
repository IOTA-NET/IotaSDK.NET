using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Faucet;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IClient
    {
        Task<IotaSDKResponse<FaucetResponse>> RequestFundsFromFaucetAsync(string bech32Address);
    }
}
