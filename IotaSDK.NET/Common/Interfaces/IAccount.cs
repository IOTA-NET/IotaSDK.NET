using IotaSDK.NET.Domain.Accounts;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public interface IAccount
    {
        Task<IotaSDKResponse<AccountBalance>> SyncAcountAsync(SyncOptions? syncOptions=null);

        Task<IotaSDKResponse<List<AccountAddress>>> GetAddressesAsync();

        Task SetAliasAsync(string alias);

        Task<IotaSDKResponse<Transaction>> SendBaseCoinAsync(ulong amount, string bech32ReceiverAddress, TransactionOptions? transactionOptions = null);

    }
}
