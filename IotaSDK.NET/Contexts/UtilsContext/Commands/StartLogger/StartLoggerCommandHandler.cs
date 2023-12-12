using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.StartLogger
{
    internal class StartLoggerCommandHandler : IRequestHandler<StartLoggerCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public StartLoggerCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }
        public async Task<IotaSDKResponse<bool>> Handle(StartLoggerCommand request, CancellationToken cancellationToken)
        {
            bool? response = await _rustBridgeCommon.InitLoggerAsync(JsonConvert.SerializeObject(request.RustLoggerConfiguration));

            if(!response.HasValue)
            {
                string? error = await _rustBridgeCommon.GetLastErrorAsync();
                throw new IotaSDKException(error);
            }

            return new IotaSDKResponse<bool>("InitLoggerAsync") { Payload = true };
        }
    }
}
