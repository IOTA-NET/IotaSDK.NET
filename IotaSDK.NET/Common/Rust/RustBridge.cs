using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IotaSDK.NET.Common.Rust
{
    public static class RustBridge
    {
        private const string DllName = "iota_sdk.dll";

        public static string GetLastError()
        {
            IntPtr errorPtr = (IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "binding_get_last_error", new object[] { }, new Type[] { });

            try
            {
                // Check if errorPtr is not null before converting to string
                return errorPtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(errorPtr) : string.Empty;
            }
            finally
            {
                // Free the allocated memory for the error string
                Marshal.FreeHGlobal(errorPtr);
            }
        }

        public static bool InitLogger(string config)
        {
            IntPtr configPtr = IntPtr.Zero;

            try
            {
                configPtr = Marshal.StringToHGlobalAnsi(config);
                return (bool)PInvoke.DynamicPInvokeBuilder(typeof(bool), DllName, "init_logger", new object[] { configPtr }, new Type[] { typeof(IntPtr) });
            }
            finally
            {
                Marshal.FreeHGlobal(configPtr);
            }
        }

        public static string CallUtilsMethod(string config)
        {
            IntPtr configPtr = IntPtr.Zero;

            try
            {
                configPtr = Marshal.StringToHGlobalAnsi(config);
                return Marshal.PtrToStringAnsi((IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "call_utils_method", new object[] { configPtr }, new Type[] { typeof(IntPtr) }));
            }
            finally
            {
                Marshal.FreeHGlobal(configPtr);
            }
        }

    }

}
