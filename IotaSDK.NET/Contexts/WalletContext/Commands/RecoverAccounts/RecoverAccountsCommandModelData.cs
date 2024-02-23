using IotaSDK.NET.Domain.Accounts;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.RecoverAccounts
{
    internal class RecoverAccountsCommandModelData
    {
        public RecoverAccountsCommandModelData(int accountStartIndex, int accountGapLimit, int addressGapLimit, SyncOptions syncOptions)
        {
            AccountStartIndex = accountStartIndex;
            AccountGapLimit = accountGapLimit;
            AddressGapLimit = addressGapLimit;
            SyncOptions = syncOptions;
        }

        public int AccountStartIndex { get; }
        public int AccountGapLimit { get; }
        public int AddressGapLimit { get; }
        public SyncOptions SyncOptions { get; }
    }
}
