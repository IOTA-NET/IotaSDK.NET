using System;
using System.Runtime.InteropServices;

namespace IotaSDK.NET.Common.Rust
{
    public static class RustBridgeWallet
    {
        private const string DllName = "iota_sdk.dll";

        public static IntPtr CreateWallet(string options)
        {
            IntPtr optionsPtr = IntPtr.Zero;

            try
            {
                optionsPtr = Marshal.StringToHGlobalAnsi(options);
                return (IntPtr)PInvoke.DynamicPInvokeBuilder(returnType: typeof(IntPtr), libraryName: DllName, methodName: "create_wallet", args: new object[] { optionsPtr }, paramTypes: new Type[] { typeof(IntPtr) });
            }
            finally
            {
                Marshal.FreeHGlobal(optionsPtr);
            }
        }

        public static bool DestroyWallet(IntPtr wallet)
        {
            return (bool)PInvoke.DynamicPInvokeBuilder(returnType: typeof(bool), libraryName: DllName, methodName: "destroy_wallet", args: new object[] { wallet }, paramTypes: new Type[] { typeof(IntPtr) });
        }

        public static string CallWalletMethod(IntPtr walletPtr, string method)
        {
            IntPtr methodPtr = IntPtr.Zero;

            try
            {
                methodPtr = Marshal.StringToHGlobalAnsi(method);
                return Marshal.PtrToStringAnsi((IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "call_wallet_method", new object[] { walletPtr, methodPtr }, new Type[] { typeof(IntPtr), typeof(IntPtr) }));
            }
            finally
            {
                Marshal.FreeHGlobal(methodPtr);
            }
        }

        public static IntPtr GetSecretManagerFromWallet(IntPtr walletPtr)
        {
            return (IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "get_secret_manager_from_wallet", new object[] { walletPtr }, new Type[] { typeof(IntPtr) });
        }


        public static IntPtr GetClientFromWallet(IntPtr walletPtr)
        {
            return (IntPtr)PInvoke.DynamicPInvokeBuilder(typeof(IntPtr), DllName, "get_client_from_wallet", new object[] { walletPtr }, new Type[] { typeof(IntPtr) });
        }


        public delegate void WalletEventHandler(IntPtr eventPtr);

        public static bool ListenWallet(IntPtr walletPtr, string events, WalletEventHandler handler)
        {
            IntPtr eventsPtr = IntPtr.Zero;

            try
            {
                eventsPtr = Marshal.StringToHGlobalAnsi(events);
                return (bool)PInvoke.DynamicPInvokeBuilder(typeof(bool), DllName, "listen_wallet", new object[] { walletPtr, eventsPtr, handler }, new Type[] { typeof(IntPtr), typeof(IntPtr), typeof(WalletEventHandler) });
            }
            finally
            {
                Marshal.FreeHGlobal(eventsPtr);
            }
        }
    }
}
