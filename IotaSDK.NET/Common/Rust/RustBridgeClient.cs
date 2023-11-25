using System.Runtime.InteropServices;
using System;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeClient
    {
        private const string DllName = "iota_sdk.dll";

        public static IntPtr CreateClient(string options)
        {
            IntPtr optionsPtr = IntPtr.Zero;

            try
            {
                optionsPtr = Marshal.StringToHGlobalAnsi(options);
                return (IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "create_client", new object[] { optionsPtr }, new Type[] { typeof(IntPtr) });
            }
            finally
            {
                Marshal.FreeHGlobal(optionsPtr);
            }
        }

        public static bool DestroyClient(IntPtr clientPtr)
        {
            return (bool)PInvoke.DynamicPInvokeBuilder(typeof(bool), DllName, "destroy_client", new object[] { clientPtr }, new Type[] { typeof(IntPtr) });
        }

        public static string CallClientMethod(IntPtr clientPtr, string method)
        {
            IntPtr methodPtr = IntPtr.Zero;

            try
            {
                methodPtr = Marshal.StringToHGlobalAnsi(method);
                return Marshal.PtrToStringAnsi((IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "call_client_method", new object[] { clientPtr, methodPtr }, new Type[] { typeof(IntPtr), typeof(IntPtr) }));
            }
            finally
            {
                Marshal.FreeHGlobal(methodPtr);
            }
        }
    }
}
