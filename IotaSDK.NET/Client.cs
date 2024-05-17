using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.ClientContext.Commands.RequestFundsFromFaucet;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetNftOutputIds;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetNode;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetNodeHealthStatus;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetOutput;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetOutputs;
using IotaSDK.NET.Domain.Faucet;
using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.Options.Builders;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET
{
    public class Client : IClient
    {
        private readonly IMediator _mediator;
        private readonly IntPtr _clientHandle;
        private readonly string? _faucetUrl;

        public Client(IMediator mediator, IntPtr clientHandle, string? faucetUrl = null)
        {
            _mediator = mediator;
            _clientHandle = clientHandle;
            _faucetUrl = faucetUrl;
        }


        public async Task<IotaSDKResponse<FaucetResponse>> RequestFundsFromFaucetAsync(string bech32Address)
        {
            return _faucetUrl == null
                ? await _mediator.Send(new RequestFundsFromFaucetCommand(_clientHandle, bech32Address))
                : await _mediator.Send(new RequestFundsFromFaucetCommand(_clientHandle, bech32Address, _faucetUrl));
        }

        public async Task<IotaSDKResponse<ClientOutputResponse>> GetOutputAsync(string outputId)
        {
            return await _mediator.Send(new GetOutputQuery(_clientHandle, outputId));
        }

        public async Task<IotaSDKResponse<List<ClientOutputResponse>>> GetOutputsAsync(List<string> outputIds)
        {
            return await _mediator.Send(new GetOutputsQuery(_clientHandle, outputIds));
        }

        public async Task<IotaSDKResponse<ClientOutputsResponse>> GetNftOutputIdsAsync(List<INftQueryParameter> nftQueryParameters)
        {
            return await _mediator.Send(new GetNftOutputIdsQuery(_clientHandle, nftQueryParameters));
        }

        public async Task<IotaSDKResponse<Node>> GetHealthyNodeAsync()
        {
            return await _mediator.Send(new GetNodeQuery(_clientHandle));
        }

        public async Task<IotaSDKResponse<bool>> GetNodeHealthStatusAsync(string url)
        {
            return await _mediator.Send(new GetNodeHealthStatusQuery(_clientHandle, url));
        }
    }
}
