﻿using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.ClientContext.Commands.RequestFundsFromFaucet;
using IotaSDK.NET.Domain.Faucet;
using MediatR;
using System;
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
    }
}
