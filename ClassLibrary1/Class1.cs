using System;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    public class Class1
    {
        private const string DllName = "iota_sdk.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr call_utils_method(IntPtr configPtr);

        public static string CallUtilsMethod(string config)
        {
            IntPtr configPtr = IntPtr.Zero;

            try
            {
                configPtr = Marshal.StringToHGlobalAnsi(config);
                IntPtr resultPtr = call_utils_method(configPtr);

                // Check if the result is not null before converting to string
                return resultPtr != IntPtr.Zero ? Marshal.PtrToStringAnsi(resultPtr) : string.Empty;
            }
            finally
            {
                Marshal.FreeHGlobal(configPtr);
            }
        }

        public class Mnemonic
        {
            public string name { get; set; } = "generateMnemonic";
        }
    }
}
