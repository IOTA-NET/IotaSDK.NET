using System.Collections.Generic;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNativeTokens
{
    internal class PrepareBurnNativeTokensCommandInnerModelData
    {
        public PrepareBurnNativeTokensCommandInnerModelData(Dictionary<string, BigInteger> nativeTokens)
        {
            NativeTokens = nativeTokens;
        }

        public Dictionary<string, BigInteger> NativeTokens { get; }
    }
}
