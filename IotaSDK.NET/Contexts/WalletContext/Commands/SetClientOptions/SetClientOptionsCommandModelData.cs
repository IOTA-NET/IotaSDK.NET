using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetClientOptions
{
    internal class SetClientOptionsCommandModelData
    {
        public SetClientOptionsCommandModelData(ClientOptions clientOptions)
        {
            ClientOptions = clientOptions;
        }

        public ClientOptions ClientOptions { get; }
    }
}
