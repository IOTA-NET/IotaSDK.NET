using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    internal class RustBridgeClient
    {
        private const string DllName = "iota_sdk.dll";

        public async Task<IntPtr?> CreateClientAsync(string options)
        {
            IntPtr optionsPtr = IntPtr.Zero;

            try
            {
                optionsPtr = Marshal.StringToHGlobalAnsi(options);
                object? client = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "create_client", new object[] { optionsPtr }, new Type[] { typeof(IntPtr) });

                if (client == null || (IntPtr)client == IntPtr.Zero)
                    return null;
                return (IntPtr?)client;
            }
            finally
            {
                Marshal.FreeHGlobal(optionsPtr);
            }
        }

        public async Task<bool?> DestroyClientAsync(IntPtr clientPtr)
        {
            object? isDestroyed = await PInvoke.DynamicPInvokeBuilderAsync(typeof(bool), DllName, "destroy_client", new object[] { clientPtr }, new Type[] { typeof(IntPtr) });

            return (bool?)isDestroyed;
        }


        public async Task<string?> CallClientMethodAsync(IntPtr clientPtr, string method)
        {
            IntPtr methodPtr = IntPtr.Zero;

            try
            {
                methodPtr = Marshal.StringToHGlobalAnsi(method);
                object? clientResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "call_client_method", new object[] { clientPtr, methodPtr }, new Type[] { typeof(IntPtr), typeof(IntPtr) });

                if (clientResponse == null || (IntPtr)clientResponse == IntPtr.Zero)
                    return null;
                else
                    return Marshal.PtrToStringAnsi((IntPtr)clientResponse);
            }
            finally
            {
                Marshal.FreeHGlobal(methodPtr);
            }
        }
    }
}
