using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IotaSDK.NET.Common.Rust
{
    public static class PInvoke
    {
        public static object? DynamicPInvokeBuilder(Type returnType, string libraryName, string methodName, object[] args, Type[] paramTypes)
        {
            AssemblyName assemblyName = new AssemblyName($"dyn1_{libraryName}");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule($"dyn2_{libraryName}");
            MethodBuilder methodBuilder = moduleBuilder.DefinePInvokeMethod(methodName, libraryName, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl, CallingConventions.Standard, returnType, paramTypes, CallingConvention.Cdecl, CharSet.Ansi);
            methodBuilder.SetImplementationFlags(methodBuilder.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);
            moduleBuilder.CreateGlobalFunctions();

            MethodInfo dynamicMethod = moduleBuilder.GetMethod(methodName);

            // Check if dynamicMethod is not null before invoking
            if (dynamicMethod != null)
            {
                try
                {
                    return dynamicMethod.Invoke(null, args);
                }
                catch (Exception ex)
                {
                    // Handle or log the exception as needed
                    Console.WriteLine($"Error invoking dynamic method {methodName}: {ex.Message}");
                }
            }

            return null;
        }

    }
}
