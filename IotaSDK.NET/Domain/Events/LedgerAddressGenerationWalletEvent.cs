namespace IotaSDK.NET.Domain.Events
{
    /// <summary>
    /// A 'ledger address generation' wallet event.
    /// </summary>
    public class LedgerAddressGenerationWalletEvent : WalletEvent
    {
        public LedgerAddressGenerationWalletEvent(string address) : base((int)WalletEventType.LedgerAddressGeneration)
        {
            Address = address;
        }

        /// <summary>
        /// The generated address.
        /// </summary>
        public string Address { get; }
    }
}
