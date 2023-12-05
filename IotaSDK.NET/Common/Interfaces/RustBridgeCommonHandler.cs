using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    internal abstract class RustBridgeCommonHandler<TRequest, TResponse, TInnerResponse, TModelData>
        : IRequestHandler<TRequest, TResponse>
        where TRequest : RustBridgeRequest<TInnerResponse>, IRequest<TResponse>
        where TResponse : IotaSDKResponse<TInnerResponse>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public RustBridgeCommonHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public abstract TModelData CreateModelData(TRequest request);
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TModelData modelData = CreateModelData(request);
            Type iotaSdkModelType = typeof(IotaSDKModel<>).MakeGenericType(typeof(TModelData));
            object[] constructorArgs = { request.RustMethodName, modelData! };

            IotaSDKModel<TModelData> model = (IotaSDKModel<TModelData>)Activator.CreateInstance(iotaSdkModelType, constructorArgs);

            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return (TResponse)IotaSDKResponse<TInnerResponse>.CreateInstance(callUtilsResponse);
        }
    }

    internal abstract class RustBridgeCommonHandler<TRequest, TResponse, TInnerResponse>
        : IRequestHandler<TRequest, TResponse>
        where TRequest : RustBridgeRequest<TInnerResponse>, IRequest<TResponse>
        where TResponse : IotaSDKResponse<TInnerResponse>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public RustBridgeCommonHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {

            IotaSDKModel model = (IotaSDKModel)Activator.CreateInstance(typeof(IotaSDKModel));

            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return (TResponse)IotaSDKResponse<TInnerResponse>.CreateInstance(callUtilsResponse);
        }
    }
}
