using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeSecretManager
    {
        #if WINDOWS
                private const string DllName = "iota_sdk.dll";

        #elif LINUX

                private const string DllName = "libiota_sdk.so";
        
        #endif


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr create_secret_manager(IntPtr optionsPtr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool destroy_secret_manager(IntPtr secretManagerPtr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr call_secret_manager_method(IntPtr secretManagerPtr, IntPtr methodPtr);

        public async Task<IntPtr?> CreateSecretManagerAsync(string options)
        {
            return await Task.Run(() =>
            {
                IntPtr optionsPtr = IntPtr.Zero;

                try
                {
                    optionsPtr = Marshal.StringToHGlobalAnsi(options);
                    IntPtr secretManagerResponse = create_secret_manager(optionsPtr);

                    if (secretManagerResponse == IntPtr.Zero)
                        return (IntPtr?)null;
                    else
                        return (IntPtr?)secretManagerResponse;
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
                return destroy_secret_manager(secretManagerPtr);
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
                    IntPtr methodResponse = call_secret_manager_method(secretManagerPtr, methodPtr);

                    if (methodResponse == IntPtr.Zero)
                        return null;
                    return Marshal.PtrToStringAnsi(methodResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(methodPtr);
                }
            });
        }
    }
}
