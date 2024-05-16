using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Faucet;
using IotaSDK.NET.Domain.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IClient
    {
        Task<IotaSDKResponse<ClientOutputResponse>> GetOutputAsync(string outputId);
        Task<IotaSDKResponse<List<ClientOutputResponse>>> GetOutputAsync(List<string> outputIds);
        Task<IotaSDKResponse<FaucetResponse>> RequestFundsFromFaucetAsync(string bech32Address);
    }
}
