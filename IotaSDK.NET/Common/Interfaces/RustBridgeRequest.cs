using IotaSDK.NET.Common.Models;
using MediatR;

namespace IotaSDK.NET.Common.Interfaces
{
    internal abstract class RustBridgeRequest<TInnerResponse> : IRequest<IotaSDKResponse<TInnerResponse>>
    {

        public RustBridgeRequest(string rustMethodName)
        {
            RustMethodName = rustMethodName;
        }

        public string RustMethodName { get; }
    }
}
