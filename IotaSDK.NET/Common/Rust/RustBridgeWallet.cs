using IotaSDK.NET.Common.Exceptions;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeWallet
    {
        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr create_wallet(IntPtr optionsPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool destroy_wallet(IntPtr wallet);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr call_wallet_method(IntPtr walletPtr, IntPtr methodPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr get_secret_manager_from_wallet(IntPtr walletPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr get_client_from_wallet(IntPtr walletPtr);

        [DllImport("iota_sdk", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool listen_wallet(IntPtr walletPtr, IntPtr eventsPtr, [MarshalAs(UnmanagedType.FunctionPtr)] WalletEventHandler handler);

        public delegate void WalletEventHandler(IntPtr eventPtr);

        public async Task<IntPtr?> CreateWalletAsync(string options)
        {
            return await Task.Run(() =>
            {
                IntPtr optionsPtr = IntPtr.Zero;

                try
                {
                    optionsPtr = Marshal.StringToHGlobalAnsi(options);
                    IntPtr walletPtr = create_wallet(optionsPtr);
                    return walletPtr == IntPtr.Zero ? (IntPtr?)null : (IntPtr?)walletPtr;
                }
                finally
                {
                    Marshal.FreeHGlobal(optionsPtr);
                }
            });
        }

        public async Task<bool?> DestroyWalletAsync(IntPtr wallet)
        {
            return await Task.Run(() => destroy_wallet(wallet));
        }

        public async Task<string?> CallWalletMethodAsync(IntPtr walletPtr, string method)
        {
            return await Task.Run(() =>
            {
                IntPtr methodPtr = IntPtr.Zero;

                try
                {
                    methodPtr = Marshal.StringToHGlobalAnsi(method);
                    IntPtr walletResponse = call_wallet_method(walletPtr, methodPtr);

                    if (walletResponse == IntPtr.Zero)
                    {
                        string? err = new RustBridgeCommon().GetLastErrorAsync().Result;
                        if (err != null)
                            throw new IotaSDKException($"Binding error: {err}");

                        return null;
                    }

                    return Marshal.PtrToStringAnsi(walletResponse);
                }
                finally
                {
                    Marshal.FreeHGlobal(methodPtr);
                }
            });
        }

        public async Task<IntPtr?> GetSecretManagerFromWalletAsync(IntPtr walletPtr)
        {
            return await Task.Run(() => get_secret_manager_from_wallet(walletPtr));
        }

        public async Task<IntPtr?> GetClientFromWalletAsync(IntPtr walletPtr)
        {
            return await Task.Run(() => get_client_from_wallet(walletPtr));
        }

        public async Task<bool?> ListenWalletAsync(IntPtr walletPtr, string events, WalletEventHandler handler)
        {
            return await Task.Run(() =>
            {
                IntPtr eventsPtr = IntPtr.Zero;

                try
                {
                    eventsPtr = Marshal.StringToHGlobalAnsi(events);
                    var x =  listen_wallet(walletPtr, eventsPtr, handler);
                    return x;
                }
                finally
                {
                    Marshal.FreeHGlobal(eventsPtr);
                }
            });
        }
    }
}
