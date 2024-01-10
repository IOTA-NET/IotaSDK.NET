using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeSecretManager
    {
        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr create_secret_manager(IntPtr optionsPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool destroy_secret_manager(IntPtr secretManagerPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
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
            return await Task.Run(() => destroy_secret_manager(secretManagerPtr));
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
