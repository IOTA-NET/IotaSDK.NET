using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeClient
    {
        private static class WindowsNativeMethods
        {
            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr create_client(IntPtr optionsPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool destroy_client(IntPtr clientPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_client_method(IntPtr clientPtr, IntPtr methodPtr);
        }

        private static class LinuxNativeMethods
        {
            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr create_client(IntPtr optionsPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool destroy_client(IntPtr clientPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_client_method(IntPtr clientPtr, IntPtr methodPtr);
        }

        public async Task<IntPtr?> CreateClientAsync(string options)
        {
            return await Task.Run(() =>
            {
                IntPtr optionsPtr = IntPtr.Zero;

                try
                {
                    optionsPtr = Marshal.StringToHGlobalAnsi(options);
                    IntPtr client = IntPtr.Zero;

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        client = WindowsNativeMethods.create_client(optionsPtr);
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        client = LinuxNativeMethods.create_client(optionsPtr);
                    else
                        throw new PlatformNotSupportedException();

                    return client == IntPtr.Zero ? (IntPtr?)null : client;
                }
                finally
                {
                    Marshal.FreeHGlobal(optionsPtr);
                }
            });
        }

        public async Task<bool?> DestroyClientAsync(IntPtr clientPtr)
        {
            return await Task.Run(() =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return WindowsNativeMethods.destroy_client(clientPtr);
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return LinuxNativeMethods.destroy_client(clientPtr);
                else
                    throw new PlatformNotSupportedException();
            });
        }

        public async Task<string?> CallClientMethodAsync(IntPtr clientPtr, string method)
        {
            return await Task.Run(() =>
            {
                IntPtr methodPtr = IntPtr.Zero;

                try
                {
                    methodPtr = Marshal.StringToHGlobalAnsi(method);
                    IntPtr clientResponse = IntPtr.Zero;

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        clientResponse = WindowsNativeMethods.call_client_method(clientPtr, methodPtr);
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        clientResponse = LinuxNativeMethods.call_client_method(clientPtr, methodPtr);
                    else
                        throw new PlatformNotSupportedException();

                    return clientResponse == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(clientResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(methodPtr);
                }
            });
        }
    }
}
