using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;


namespace IotaSDK.NET.Domain.Accounts
{

    public class AccountBalance
    {

        public AccountBalance(BaseCoinBalance baseCoin, RequiredStorageDeposit requiredStorageDeposit)
        {
            BaseCoin = baseCoin;
            RequiredStorageDeposit = requiredStorageDeposit;
        }

        /// <summary>
        /// The balance of the base coin
        /// </summary>
        public BaseCoinBalance BaseCoin { get; set; }


        /// <summary>
        /// The required storage deposit for the outputs
        /// </summary>
        public RequiredStorageDeposit RequiredStorageDeposit { get; set; }


        /// <summary>
        /// The balance of the native tokens
        /// </summary>
        public List<NativeTokenBalance> NativeTokens { get; set; } = new List<NativeTokenBalance>();

        /// <summary>
        /// Nft Outputs
        /// </summary>
        public List<string> Nfts { get; set; } = new List<string>();

        /// <summary>
        /// Aliases outputs
        /// </summary>
        public List<string> Aliases { get; set; } = new List<string>();

        /// <summary>
        /// Foundry outputs
        /// </summary>
        public List<string> Foundries { get; set; } = new List<string>();

        /// <summary>
        ///  Outputs with multiple unlock conditions and if they can currently be spent or not. If there is a
        ///  TimelockUnlockCondition or ExpirationUnlockCondition this can change at any time
        /// </summary>
        public Dictionary<string, bool> PotentiallyLockedOutputs { get; set; } = new Dictionary<string, bool>();
    }
}
