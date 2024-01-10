using IotaSDK.NET.Common.Exceptions;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public class RustBridgeWallet
    {
        private static class WindowsNativeMethods
        {
            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr create_wallet(IntPtr optionsPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool destroy_wallet(IntPtr wallet);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_wallet_method(IntPtr walletPtr, IntPtr methodPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr get_secret_manager_from_wallet(IntPtr walletPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr get_client_from_wallet(IntPtr walletPtr);

            [DllImport("iota_sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool listen_wallet(IntPtr walletPtr, IntPtr eventsPtr, WalletEventHandler handler);
        }

        private static class LinuxNativeMethods
        {
            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr create_wallet(IntPtr optionsPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool destroy_wallet(IntPtr wallet);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr call_wallet_method(IntPtr walletPtr, IntPtr methodPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr get_secret_manager_from_wallet(IntPtr walletPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern IntPtr get_client_from_wallet(IntPtr walletPtr);

            [DllImport("libiota_sdk.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern bool listen_wallet(IntPtr walletPtr, IntPtr eventsPtr, WalletEventHandler handler);
        }

        public delegate void WalletEventHandler(IntPtr eventPtr);

        public async Task<IntPtr?> CreateWalletAsync(string options)
        {
            return await Task.Run(() =>
            {
                IntPtr optionsPtr = IntPtr.Zero;

                try
                {
                    optionsPtr = Marshal.StringToHGlobalAnsi(options);
                    IntPtr walletPtr = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                        ? WindowsNativeMethods.create_wallet(optionsPtr)
                        : LinuxNativeMethods.create_wallet(optionsPtr);

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
            return await Task.Run(() =>
            {
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? WindowsNativeMethods.destroy_wallet(wallet)
                    : LinuxNativeMethods.destroy_wallet(wallet);
            });
        }

        public async Task<string?> CallWalletMethodAsync(IntPtr walletPtr, string method)
        {
            return await Task.Run(() =>
            {
                IntPtr methodPtr = IntPtr.Zero;

                try
                {
                    methodPtr = Marshal.StringToHGlobalAnsi(method);
                    IntPtr walletResponse = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                        ? WindowsNativeMethods.call_wallet_method(walletPtr, methodPtr)
                        : LinuxNativeMethods.call_wallet_method(walletPtr, methodPtr);

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
            return await Task.Run(() =>
            {
                IntPtr secretManager = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? WindowsNativeMethods.get_secret_manager_from_wallet(walletPtr)
                    : LinuxNativeMethods.get_secret_manager_from_wallet(walletPtr);

                return secretManager == IntPtr.Zero ? (IntPtr?)null : (IntPtr?)secretManager;
            });
        }

        public async Task<IntPtr?> GetClientFromWalletAsync(IntPtr walletPtr)
        {
            return await Task.Run(() =>
            {
                IntPtr client = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? WindowsNativeMethods.get_client_from_wallet(walletPtr)
                    : LinuxNativeMethods.get_client_from_wallet(walletPtr);

                return client == IntPtr.Zero ? (IntPtr?)null : (IntPtr?)client;
            });
        }

        public async Task<bool?> ListenWalletAsync(IntPtr walletPtr, string events, WalletEventHandler handler)
        {
            return await Task.Run(() =>
            {
                IntPtr eventsPtr = IntPtr.Zero;

                try
                {
                    eventsPtr = Marshal.StringToHGlobalAnsi(events);
                    return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                        ? WindowsNativeMethods.listen_wallet(walletPtr, eventsPtr, handler)
                        : LinuxNativeMethods.listen_wallet(walletPtr, eventsPtr, handler);
                }
                finally
                {
                    Marshal.FreeHGlobal(eventsPtr);
                }
            });
        }
    }
}
