using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeCommon
    {
        private static class WindowsNativeMethods
        {
            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr binding_get_last_error();

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool init_logger(IntPtr configPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_utils_method(IntPtr configPtr);
        }

        private static class LinuxNativeMethods
        {
            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr binding_get_last_error();

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool init_logger(IntPtr configPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_utils_method(IntPtr configPtr);
        }

        public RustBridgeCommon()
        {
            // Constructor code if necessary
        }

        public async Task<string?> GetLastErrorAsync()
        {
            return await Task.Run(() =>
            {
                IntPtr errorResponse;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    errorResponse = WindowsNativeMethods.binding_get_last_error();
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    errorResponse = LinuxNativeMethods.binding_get_last_error();
                else
                    throw new PlatformNotSupportedException();

                try
                {
                    return errorResponse == IntPtr.Zero
                        ? null
                        : Marshal.PtrToStringAnsi(errorResponse);
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
                    return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                        ? WindowsNativeMethods.init_logger(configPtr)
                        : LinuxNativeMethods.init_logger(configPtr);
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
                    IntPtr utilsResponse;
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        utilsResponse = WindowsNativeMethods.call_utils_method(configPtr);
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        utilsResponse = LinuxNativeMethods.call_utils_method(configPtr);
                    else
                        throw new PlatformNotSupportedException();

                    return utilsResponse == IntPtr.Zero
                        ? null
                        : Marshal.PtrToStringAnsi(utilsResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(configPtr);
                }
            });
        }
    }
}
