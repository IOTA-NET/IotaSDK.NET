using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeCommon
    {
        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr binding_get_last_error();

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool init_logger(IntPtr configPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr call_utils_method(IntPtr configPtr);

        public RustBridgeCommon()
        {
            // Constructor code if necessary
        }

        public async Task<string?> GetLastErrorAsync()
        {
            return await Task.Run(() =>
            {
                IntPtr errorResponse = binding_get_last_error();
                try
                {
                    return errorResponse == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(errorResponse);
                }
                finally
                {
                    if (errorResponse != IntPtr.Zero)
                        Marshal.FreeHGlobal(errorResponse);
                }
            });
        }

        public async Task<bool?> InitLoggerAsync(string config)
        {
            return await Task.Run(() =>
            {
                IntPtr configPtr = IntPtr.Zero;

                try
                {
                    configPtr = Marshal.StringToHGlobalAnsi(config);
                    return init_logger(configPtr);
                }
                finally
                {
                    Marshal.FreeHGlobal(configPtr);
                }
            });
        }

        public async Task<string?> CallUtilsMethodAsync(string config)
        {
            return await Task.Run(() =>
            {
                IntPtr configPtr = IntPtr.Zero;

                try
                {
                    configPtr = Marshal.StringToHGlobalAnsi(config);
                    IntPtr utilsResponse = call_utils_method(configPtr);

                    return utilsResponse == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(utilsResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(configPtr);
                }
            });
        }
    }
}
