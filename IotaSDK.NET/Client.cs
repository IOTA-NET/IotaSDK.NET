using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetOutput;
using IotaSDK.NET.Contexts.ClientContext.Commands.RequestFundsFromFaucet;
using IotaSDK.NET.Domain.Faucet;
using MediatR;
using System;
using System.Threading.Tasks;
using IotaSDK.NET.Domain.Outputs;
using System.Collections.Generic;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetOutputs;
using IotaSDK.NET.Domain.Queries;
using IotaSDK.NET.Contexts.ClientContext.Queries.GetNftOutputIds;

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
    }
}
