using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Options.PrepareOutput;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace IotaSDK.NET.Domain.Tokens
{
    public class SendNativeTokensBuilder
    {
        private SendNativeTokensOptionsBuilder? _sendNativeTokensOptionsBuilder;
        private List<SendNativeTokensOptions> _nativeTokensOptions;
        List<bool> _giftStorageDepositOptions;
        private readonly IAccount _account;

        public SendNativeTokensBuilder(IAccount account)
        {
            _giftStorageDepositOptions = new List<bool>();
            _nativeTokensOptions = new List<SendNativeTokensOptions>();
            _account = account;
        }

        public SendNativeTokensOptionsBuilder AddNativeTokensOptions()
        {
            _sendNativeTokensOptionsBuilder = new SendNativeTokensOptionsBuilder(this, x => _nativeTokensOptions.Add(x), x => _giftStorageDepositOptions.Add(x));

            return _sendNativeTokensOptionsBuilder;
        }
        public async Task<IotaSDKResponse<Transaction>> SendAsync(TransactionOptions? transactionOptions = null)
        {
            List<Output> outputs = new List<Output>();

            for (int i = 0; i < _nativeTokensOptions.Count; i++)
            {
                var sendNativeTokensOptions = _nativeTokensOptions[i];
                var nativeTokens = sendNativeTokensOptions.NativeTokens.Select(x => new NativeToken(id: x[0], new BigInteger(x[1].FromHexToULong()))).ToList();
                PrepareOutputAssetOptions prepareOutputAssetOptions = new PrepareOutputAssetOptions(nativeTokens, nftId: null);

                PrepareOutputStorageDepositOptions prepareOutputStorageDepositOptions = new PrepareOutputStorageDepositOptions(_giftStorageDepositOptions[i] ? PrepareOutputReturnStrategyType.Gift : PrepareOutputReturnStrategyType.Return, useExcessIfLow: false);

                
                PrepareOutputOptions prepareOutputOptions = new PrepareOutputOptions(sendNativeTokensOptions.Address, amount: 0, prepareOutputAssetOptions, features: null, unlocks: null, prepareOutputStorageDepositOptions);

                Output output = (await _account.PrepareOutputAsync(prepareOutputOptions, transactionOptions)).Payload;
                outputs.Add(output);

            }

            return await _account.SendTransactionAsync(outputs, transactionOptions);
        }
    }
}
