using IotaSDK.NET.Domain.Options;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Tokens
{
    public class SendNativeTokensOptionsBuilder
    {
        private string? _address;
        private List<KeyValuePair<string, ulong>> _nativeTokens = new List<KeyValuePair<string, ulong>>();
        private readonly SendNativeTokensBuilder _sendNativeTokensBuilder;
        private readonly Action<SendNativeTokensOptions> _addOptionsAction;
        private readonly Action<bool> _setGiftStorageAction;
        private bool? _shouldGiftStorage;
        private ulong? _expiration;
        private string? _returnAddress;

        public SendNativeTokensOptionsBuilder(
            SendNativeTokensBuilder sendNativeTokensBuilder,
            Action<SendNativeTokensOptions> AddOptionsAction,
            Action<bool> SetGiftStorageAction)
        {
            _sendNativeTokensBuilder = sendNativeTokensBuilder;
            _addOptionsAction = AddOptionsAction;
            _setGiftStorageAction = SetGiftStorageAction;
        }

        public SendNativeTokensOptionsBuilder UseGiftStorage(bool shouldGiftStorage = true)
        {
            _shouldGiftStorage = shouldGiftStorage;
            return this;
        }

        public SendNativeTokensOptionsBuilder SetReceiverAddress(string receiverAddress)
        {
            _address = receiverAddress;
            return this;
        }

        public SendNativeTokensOptionsBuilder SetStorageDepositReturnAddress(string storageDepositReturnAddress)
        {
            _returnAddress = storageDepositReturnAddress;
            return this;
        }

        public SendNativeTokensOptionsBuilder SetExpirationTime(TimeSpan timeSpan)
        {
            DateTime futureTime = DateTime.Now + timeSpan;
            long unixTime = ((DateTimeOffset)futureTime).ToUnixTimeSeconds();
            _expiration = (ulong)unixTime;

            return this;
        }

        public SendNativeTokensOptionsBuilder AddNativeTokens(string tokenId, ulong numberOfTokens)
        {
            KeyValuePair<string, ulong> keyValuePair = new KeyValuePair<string, ulong>(tokenId, numberOfTokens);
            _nativeTokens.Add(keyValuePair);
            return this;
        }

        public SendNativeTokensBuilder Then()
        {
            if (_address == null)
                throw new ArgumentNullException("Address for SendNativeTokensOptions is empty.");
            if (_nativeTokens.Count == 0)
                throw new ArgumentException("No native tokens specified for SendNativeTokensOptionsBuilder");

            SendNativeTokensOptions sendNativeTokensOptions = new SendNativeTokensOptions(_address, _nativeTokens, _returnAddress, _expiration);
            _addOptionsAction(sendNativeTokensOptions);

            _setGiftStorageAction(_shouldGiftStorage == null ? false : true);
            return _sendNativeTokensBuilder;
        }

    }
}
