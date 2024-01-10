using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeSecretManager
    {
        private static class WindowsNativeMethods
        {
            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr create_secret_manager(IntPtr optionsPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool destroy_secret_manager(IntPtr secretManagerPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_secret_manager_method(IntPtr secretManagerPtr, IntPtr methodPtr);
        }

        private static class LinuxNativeMethods
        {
            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr create_secret_manager(IntPtr optionsPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool destroy_secret_manager(IntPtr secretManagerPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_secret_manager_method(IntPtr secretManagerPtr, IntPtr methodPtr);
        }

        public async Task<IntPtr?> CreateSecretManagerAsync(string options)
        {
            return await Task.Run(() =>
            {
                IntPtr optionsPtr = IntPtr.Zero;

                try
                {
                    optionsPtr = Marshal.StringToHGlobalAnsi(options);
                    IntPtr secretManagerResponse;
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        secretManagerResponse = WindowsNativeMethods.create_secret_manager(optionsPtr);
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        secretManagerResponse = LinuxNativeMethods.create_secret_manager(optionsPtr);
                    else
                        throw new PlatformNotSupportedException();

                    return secretManagerResponse == IntPtr.Zero ? (IntPtr?)null : (IntPtr?)secretManagerResponse;
                }
                finally
                {
                    Marshal.FreeHGlobal(optionsPtr);
                }
            });
        }

        public async Task<bool?> DestroySecretManagerAsync(IntPtr secretManagerPtr)
        {
            return await Task.Run(() =>
            {
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? WindowsNativeMethods.destroy_secret_manager(secretManagerPtr)
                    : LinuxNativeMethods.destroy_secret_manager(secretManagerPtr);
            });
        }

        public async Task<string?> CallSecretManagerMethodAsync(IntPtr secretManagerPtr, string method)
        {
            return await Task.Run(() =>
            {
                IntPtr methodPtr = IntPtr.Zero;

                try
                {
                    methodPtr = Marshal.StringToHGlobalAnsi(method);
                    IntPtr methodResponse;
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        methodResponse = WindowsNativeMethods.call_secret_manager_method(secretManagerPtr, methodPtr);
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        methodResponse = LinuxNativeMethods.call_secret_manager_method(secretManagerPtr, methodPtr);
                    else
                        throw new PlatformNotSupportedException();

                    return methodResponse == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(methodResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(methodPtr);
                }
            });
        }
    }
}
