using IotaSDK.NET.Domain.Accounts;

namespace IotaSDK.NET.Contexts.SecretManagerContext.Command.SignStringDataCommand
{
    internal class SignStringDataCommandModelData
    {
        public SignStringDataCommandModelData(string message, Bip44 chain)
        {
            Message = message;
            Chain = chain;
        }

        public string Message { get; }
        public Bip44 Chain { get; }
    }
}
