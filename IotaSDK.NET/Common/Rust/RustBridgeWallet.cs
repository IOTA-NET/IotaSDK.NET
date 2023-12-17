using IotaSDK.NET.Common.Exceptions;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeWallet
    {
        private const string DllName = "iota_sdk.dll";

        public async Task<IntPtr?> CreateWalletAsync(string options)
        {
            IntPtr optionsPtr = IntPtr.Zero;

            try
            {
                optionsPtr = Marshal.StringToHGlobalAnsi(options);
                object? walletPtr = await PInvoke.DynamicPInvokeBuilderAsync(returnType: typeof(IntPtr), libraryName: DllName, methodName: "create_wallet", args: new object[] { optionsPtr }, paramTypes: new Type[] { typeof(IntPtr) });
                if (walletPtr == null || (IntPtr)walletPtr! == IntPtr.Zero)
                {
                    return null;
                }

                return (IntPtr)walletPtr;
            }
            finally
            {
                Marshal.FreeHGlobal(optionsPtr);
            }
        }

        public async Task<bool?> DestroyWalletAsync(IntPtr wallet)
        {
            object? isDestroyed = await PInvoke.DynamicPInvokeBuilderAsync(returnType: typeof(bool), libraryName: DllName, methodName: "destroy_wallet", args: new object[] { wallet }, paramTypes: new Type[] { typeof(IntPtr) });
            return (bool?)isDestroyed;
        }

        public async Task<string?> CallWalletMethodAsync(IntPtr walletPtr, string method)
        {
            IntPtr methodPtr = IntPtr.Zero;

            try
            {
                methodPtr = Marshal.StringToHGlobalAnsi(method);
                object? walletResponse = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "call_wallet_method", new object[] { walletPtr, method }, new Type[] { typeof(IntPtr), typeof(string) });

                if (walletResponse == null || (IntPtr)walletResponse == IntPtr.Zero)
                {
                    string? err = await new RustBridgeCommon().GetLastErrorAsync();
                    if (err != null)
                        throw new IotaSDKException($"Binding error: {err}");

                    return null;
                }

                return Marshal.PtrToStringAnsi((IntPtr)walletResponse);
            }
            finally
            {
                Marshal.FreeHGlobal(methodPtr);
            }
        }

        public async Task<IntPtr?> GetSecretManagerFromWalletAsync(IntPtr walletPtr)
        {
            object? secretManager = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "get_secret_manager_from_wallet", new object[] { walletPtr }, new Type[] { typeof(IntPtr) });

            if (secretManager == null || (IntPtr)secretManager == IntPtr.Zero)
            {
                return null;
            }

            return (IntPtr)secretManager;
        }


        public async Task<IntPtr?> GetClientFromWalletAsync(IntPtr walletPtr)
        {
            object? client = await PInvoke.DynamicPInvokeBuilderAsync(typeof(IntPtr), DllName, "get_client_from_wallet", new object[] { walletPtr }, new Type[] { typeof(IntPtr) });

            if (client == null || (IntPtr)client == IntPtr.Zero)
            {
                return null;
            }

            return (IntPtr)client;
        }


        public delegate void WalletEventHandler(IntPtr eventPtr);

        public async Task<bool?> ListenWalletAsync(IntPtr walletPtr, string events, WalletEventHandler handler)
        {
            IntPtr eventsPtr = IntPtr.Zero;

            try
            {
                eventsPtr = Marshal.StringToHGlobalAnsi(events);
                object? listening = await PInvoke.DynamicPInvokeBuilderAsync(typeof(bool), DllName, "listen_wallet", new object[] { walletPtr, eventsPtr, handler }, new Type[] { typeof(IntPtr), typeof(IntPtr), typeof(WalletEventHandler) });

                return (bool?)listening;
            }
            finally
            {
                Marshal.FreeHGlobal(eventsPtr);
            }
        }
    }
}
