using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Signatures;
using System;

namespace IotaSDK.NET.Contexts.SecretManagerContext.Command.SignStringDataCommand
{
    internal class SignStringDataCommand : SecretManagerRequest<IotaSDKResponse<Signature>>
    {
        public SignStringDataCommand(IntPtr secretManagerHandler, string data, Bip44 chain) : base(secretManagerHandler)
        {
            Data = data.ToHexString();
            Chain = chain;
        }

        public string Data { get; }
        public Bip44 Chain { get; }
    }
}
