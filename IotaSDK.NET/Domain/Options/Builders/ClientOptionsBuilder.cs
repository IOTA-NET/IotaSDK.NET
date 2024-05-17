using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IotaSDK.NET.Domain.Options.Builders
{
    public class ClientOptionsBuilder
    {
        private readonly IWallet? _wallet;
        private readonly ClientOptions _clientOptions;
        private readonly IMediator _mediator;

        public ClientOptionsBuilder(IWallet wallet)
        {
            _wallet = wallet;
            _clientOptions = _wallet.GetWalletOptions().ClientOptions;
            _mediator = _wallet.GetMediator();
        }

        public ClientOptionsBuilder(IMediator mediator)
        {
            _wallet = null;
            _clientOptions = new ClientOptions();
            _mediator = mediator;
        }

        public ClientOptionsBuilder AddNodeUrl(string nodeUrl)
        {
            _clientOptions.Nodes.Add(nodeUrl);
            return this;
        }

        public ClientOptionsBuilder IsLocalPow(bool isLocalPow = true)
        {
            _clientOptions.LocalPow = isLocalPow;
            return this;
        }

        public ClientOptionsBuilder SetFaucetUrl(string faucetUrl)
        {
            _clientOptions.FaucetUrl = faucetUrl;
            return this;
        }

        public ClientOptions GetClientOptions() => _clientOptions;

        public async Task<IClient> CreateClientAsync()
        { 
            RustBridgeClient rustBridgeClient = new RustBridgeClient();
            IntPtr? clientHandle = await rustBridgeClient.CreateClientAsync(JsonConvert.SerializeObject(GetClientOptions()));
            IClient client = new Client(_mediator, clientHandle.Value, _clientOptions.FaucetUrl);
            return client;
        }

        public IWallet Then()
        {
            //To trigger json re-construction
            _wallet!.GetWalletOptions().ClientOptions = _clientOptions;
            return _wallet;
        }
    }
}
