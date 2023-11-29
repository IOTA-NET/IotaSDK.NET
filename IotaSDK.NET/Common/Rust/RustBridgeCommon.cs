using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeCommon
    {
        private const string DllName = "iota_sdk.dll";

        public RustBridgeCommon()
        {

        }
        public async Task<string?> GetLastErrorAsync()
        {
            object? errorResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "binding_get_last_error", new object[] { }, new Type[] { });

            try
            {
                return errorResponse == null || (IntPtr)errorResponse == IntPtr.Zero
                    ? null
                    : Marshal.PtrToStringAnsi((IntPtr)errorResponse);
            }
            finally
            {
                if (errorResponse != null)
                    Marshal.FreeHGlobal((IntPtr)errorResponse!);
            }
        }

        public async Task<bool?> InitLoggerAsync(string config)
        {
            IntPtr configPtr = IntPtr.Zero;

            try
            {
                configPtr = Marshal.StringToHGlobalAnsi(config);
                object? loggerInitResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(bool), DllName, "init_logger", new object[] { configPtr }, new Type[] { typeof(IntPtr) });
                return (bool?)loggerInitResponse;
            }
            finally
            {
                Marshal.FreeHGlobal(configPtr);
            }
        }

        public async Task<string?> CallUtilsMethodAsync(string config)
        {
            IntPtr configPtr = IntPtr.Zero;

            try
            {
                configPtr = Marshal.StringToHGlobalAnsi(config);
                object? utilsResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "call_utils_method", new object[] { configPtr }, new Type[] { typeof(IntPtr) });

                if (utilsResponse == null || (IntPtr)utilsResponse == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAnsi((IntPtr)utilsResponse);
            }
            finally
            {
                Marshal.FreeHGlobal(configPtr);
            }
        }

    }

}
