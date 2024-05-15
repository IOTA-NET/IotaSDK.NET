using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Signatures;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.SecretManagerContext.Command.SignStringDataCommand
{
    internal class SignStringDataCommandHandler : IRequestHandler<SignStringDataCommand, IotaSDKResponse<Signature>>
    {
        private readonly RustBridgeSecretManager _rustBridgeSecretManager;

        public SignStringDataCommandHandler(RustBridgeSecretManager rustBridgeSecretManager)
        {
            _rustBridgeSecretManager = rustBridgeSecretManager;
        }

        public async Task<IotaSDKResponse<Signature>> Handle(SignStringDataCommand request, CancellationToken cancellationToken)
        {
            var model = new IotaSDKModel<SignStringDataCommandModelData>("signEd25519", new SignStringDataCommandModelData(request.Data, request.Chain));
            string json = model.AsJson();

            string? secretManagerResponse = await _rustBridgeSecretManager.CallSecretManagerMethodAsync(request.SecretManagerHandle, json);

            IotaSDKException.CheckForException(secretManagerResponse!);


            var response =  IotaSDKResponse<Signature>.CreateInstance(secretManagerResponse);
            return response;
        }

    }
}
