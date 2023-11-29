using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Rust
{
    public static class PInvoke
    {
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public static async Task<object?> DynamicPInvokeBuilderAsync(Type returnType, string libraryName, string methodName, object[] args, Type[] paramTypes)
        {
            await _semaphore.WaitAsync();
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
                    var response = dynamicMethod.Invoke(null, args);
                    return response;
                }
                catch (Exception ex)
                {
                    // Handle or log the exception as needed
                    Console.WriteLine($"Error invoking dynamic method {methodName}: {ex.Message}");
                }
                finally
                { _semaphore.Release(); }
            }

            return null;
        }

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
                    var response = dynamicMethod.Invoke(null, args);
                    return response;
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
