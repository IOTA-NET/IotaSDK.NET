using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeSecretManager
    {
        private const string DllName = "iota_sdk.dll";

        public async Task<IntPtr?> CreateSecretManagerAsync(string options)
        {
            IntPtr optionsPtr = IntPtr.Zero;

            try
            {
                optionsPtr = Marshal.StringToHGlobalAnsi(options);
                object? secretManagerResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "create_secret_manager", new object[] { optionsPtr }, new Type[] { typeof(IntPtr) });
                if (secretManagerResponse == null || (IntPtr)secretManagerResponse == IntPtr.Zero)
                    return null;
                else
                    return (IntPtr)secretManagerResponse;
            }
            finally
            {
                Marshal.FreeHGlobal(optionsPtr);
            }
        }

        public async Task<bool?> DestroySecretManagerAsync(IntPtr secretManagerPtr)
        {
            object? isDestroyed = await PInvoke.DynamicPInvokeBuilderAsync(typeof(bool), DllName, "destroy_secret_manager", new object[] { secretManagerPtr }, new Type[] { typeof(IntPtr) });
            return (bool?)isDestroyed;
        }

        public async Task<string?> CallSecretManagerMethodAsync(IntPtr secretManagerPtr, string method)
        {
            IntPtr methodPtr = IntPtr.Zero;

            try
            {
                methodPtr = Marshal.StringToHGlobalAnsi(method);
                object? methodResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "call_secret_manager_method", new object[] { secretManagerPtr, methodPtr }, new Type[] { typeof(IntPtr), typeof(IntPtr) });

                if (methodResponse == null || (IntPtr)methodResponse == IntPtr.Zero)
                    return null;
                return Marshal.PtrToStringAnsi((IntPtr)methodResponse);
            }
            finally
            {
                Marshal.FreeHGlobal(methodPtr);
            }
        }
    }
}
