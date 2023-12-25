using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotaSDK.NET.Domain.Nft
{
    public class MintNftBuilder
    {
        private readonly IAccount _account;
        private NftOptionsBuilder _optionsBuilder;
        private List<NftOptions> _options;

        public MintNftBuilder(IAccount account)
        {
            _options = new List<NftOptions>();
            _account = account;
        }

        public NftOptionsBuilder CreateNewNft()
        {
            _optionsBuilder = new NftOptionsBuilder(this, x => _options.Add(x));
            return _optionsBuilder;
        }


        public async Task<IotaSDKResponse<Transaction>> MinftNftsAsync(TransactionOptions? transactionOptions = null)
        {
            if (_options.Any() == false)
                throw new IotaSDKException("No nft created. Do use 'CreateNewNft' method");

            return await _account.MintNftsAsync(_options, transactionOptions);
        }
    }
}
