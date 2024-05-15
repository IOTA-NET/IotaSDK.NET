using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.SecretManagerContext.Command.SignStringDataCommand;
using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Signatures;
using MediatR;
using System;
using System.Threading.Tasks;

namespace IotaSDK.NET
{
    public class SecretManager : ISecretManager
    {
        private readonly IMediator _mediator;
        private readonly IntPtr _secretManagerHandle;

        public SecretManager(IMediator mediator, IntPtr secretManagerHandle)
        {
            _mediator = mediator;
            _secretManagerHandle = secretManagerHandle;
        }

        public async Task<IotaSDKResponse<Signature>> SignStringDataAsync(string data, Bip44 chain)
        {
            return await _mediator.Send(new SignStringDataCommand(_secretManagerHandle, data, chain));
        }
    }
}
