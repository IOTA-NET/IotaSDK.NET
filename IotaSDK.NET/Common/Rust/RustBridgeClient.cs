using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeClient
    {
        #if WINDOWS
                private const string DllName = "iota_sdk.dll";

        #elif LINUX

                private const string DllName = "libiota_sdk.so";
        
        #endif

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr create_client(IntPtr optionsPtr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool destroy_client(IntPtr clientPtr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr call_client_method(IntPtr clientPtr, IntPtr methodPtr);

        public async Task<IntPtr?> CreateClientAsync(string options)
        {
            return await Task.Run(() =>
            {
                IntPtr optionsPtr = IntPtr.Zero;

                try
                {
                    optionsPtr = Marshal.StringToHGlobalAnsi(options);
                    IntPtr client = create_client(optionsPtr);

                    if (client == IntPtr.Zero)
                        return (IntPtr?)null;
                    return (IntPtr?)client;
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
                return destroy_client(clientPtr);
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
                    IntPtr clientResponse = call_client_method(clientPtr, methodPtr);

                    if (clientResponse == IntPtr.Zero)
                        return null;
                    else
                        return Marshal.PtrToStringAnsi(clientResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(methodPtr);
                }
            });
        }
    }
}
