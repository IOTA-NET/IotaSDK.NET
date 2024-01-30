using IotaSDK.NET.Common.Serializers;
using Newtonsoft.Json;
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
            [JsonConverter(typeof(DictBigIntJsonConverter))]
            public Dictionary<string, BigInteger> NativeTokens { get; }
    }
}
