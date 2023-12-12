using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.StartLogger
{
    internal class StartLoggerCommand : IRequest<IotaSDKResponse<bool>>
    {
        public StartLoggerCommand(RustLoggerConfiguration rustLoggerConfiguration)
        {
            RustLoggerConfiguration = rustLoggerConfiguration;
        }

        public RustLoggerConfiguration RustLoggerConfiguration { get; }
    }
}
