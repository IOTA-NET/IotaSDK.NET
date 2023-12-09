using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Accounts
{
    public class AccountMeta
    {
        /// <summary>
        /// The account index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The type of coin managed with the account
        /// </summary>
        public TypeOfCoin CoinType { get; set; }

        /// <summary>
        /// The alias name of the account
        /// </summary>
        public string Alias { get; set; } = string.Empty;

        /// <summary>
        /// All public addresses
        /// </summary>
        public List<AccountAddress> PublicAddresses { get; set; } = new List<AccountAddress>();

        /// <summary>
        /// All internal addresses
        /// </summary>
        public List<AccountAddress> InternalAddresses { get; set; } = new List<AccountAddress>();

        public List<AddressWithUnspentOutputs> AddressesWithUnspentOutputs { get; set; } = new List<AddressWithUnspentOutputs>();

        public Dictionary<string, OutputData> Outputs { get; set; } = new Dictionary<string, OutputData>();

        /// <summary>
        ///  Output IDs of unspent outputs that are currently used as input for transactions
        /// </summary>
        public HashSet<string> LockedOutputs { get; set; } = new HashSet<string>();

        public Dictionary<string, OutputData> UnspentOutputs { get; set; } = new Dictionary<string, OutputData>();

        /// <summary>
        /// All transactions of the account.
        /// </summary>
        public Dictionary<string, Transaction> Transactions { get; set; } = new Dictionary<string, Transaction>();

        /// <summary>
        /// All incoming transactions of the account (with their inputs if available and not already pruned).
        /// </summary>
        public Dictionary<string, Transaction> IncomingTransactions { get; set; } = new Dictionary<string, Transaction>();

        /// <summary>
        /// All pending transactions of the account.
        /// </summary>
        public HashSet<string> PendingTransactions { get; set; } = new HashSet<string>();


    }
}
