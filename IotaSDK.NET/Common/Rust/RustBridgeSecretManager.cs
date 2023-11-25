using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace IotaSDK.NET.Common.Rust
{
    public static class RustBridgeSecretManager
    {
        private const string DllName = "iota_sdk.dll";

        public static IntPtr CreateSecretManager(string options)
        {
            IntPtr optionsPtr = IntPtr.Zero;

            try
            {
                optionsPtr = Marshal.StringToHGlobalAnsi(options);
                return (IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "create_secret_manager", new object[] { optionsPtr }, new Type[] { typeof(IntPtr) });
            }
            finally
            {
                Marshal.FreeHGlobal(optionsPtr);
            }
        }

        public static bool DestroySecretManager(IntPtr secretManagerPtr)
        {
            return (bool)PInvoke.DynamicPInvokeBuilder(typeof(bool), DllName, "destroy_secret_manager", new object[] { secretManagerPtr }, new Type[] { typeof(IntPtr) });
        }

        public static string CallSecretManagerMethod(IntPtr secretManagerPtr, string method)
        {
            IntPtr methodPtr = IntPtr.Zero;

            try
            {
                methodPtr = Marshal.StringToHGlobalAnsi(method);
                return Marshal.PtrToStringAnsi((IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "call_secret_manager_method", new object[] { secretManagerPtr, methodPtr }, new Type[] { typeof(IntPtr), typeof(IntPtr) }));
            }
            finally
            {
                Marshal.FreeHGlobal(methodPtr);
            }
        }
    }
}
