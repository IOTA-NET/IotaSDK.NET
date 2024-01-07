using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Threading.Tasks;

namespace IotaSDK.NET.Domain.Tokens
{
    public class CreateNativeTokenBuilder
    {
        private NativeTokenIrc30Builder _nativeTokenIrc30Builder;
        private NativeTokenIrc30? _nativeTokenIrc30;
        private NativeToken? _nativeToken;
        private ulong? _circulatingSupply, _maximumSupply;
        private string? _aliasId;
        private readonly IAccount _account;

        public CreateNativeTokenBuilder(IAccount account)
        {
            _nativeTokenIrc30Builder = new NativeTokenIrc30Builder(this, x => _nativeTokenIrc30 = x);
            _circulatingSupply = null;
            _maximumSupply = null;
            _aliasId = null;
            _account = account;
        }

        public NativeTokenIrc30Builder SetFoundryMetadata()
        {
            return _nativeTokenIrc30Builder;
        }

        public CreateNativeTokenBuilder SetCirculatingSupply(ulong circulatingSupply)
        {
            _circulatingSupply = circulatingSupply;
            return this;
        }

        public CreateNativeTokenBuilder SetMaximumSupply(ulong maximumSupply)
        {
            _maximumSupply = maximumSupply;
            return this;
        }

        public CreateNativeTokenBuilder SetAliasId(string aliasId)
        {
            _aliasId = aliasId;
            return this;
        }

        public async Task<IotaSDKResponse<Transaction>> CreateNativeTokensAsync(TransactionOptions? transactionOptions = null)
        {
            if (_circulatingSupply == null || _maximumSupply == null)
                throw new ArgumentNullException("Set both Circulating supply and Maximum supply");

            NativeTokenCreationOptions creationOptions = new NativeTokenCreationOptions(_circulatingSupply.Value, _maximumSupply.Value, _nativeTokenIrc30, _aliasId);
            return await _account.CreateNativeTokenAsync(creationOptions, transactionOptions);
        }

    }
}
