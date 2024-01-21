namespace IotaSDK.NET.Domain.Events
{
    /// <summary>
    ///  A 'consolidation required' wallet event.
    /// </summary>
    public class ConsolidationRequiredWalletEvent : WalletEvent
    {
        public ConsolidationRequiredWalletEvent() : base((int)WalletEventType.ConsolidationRequired)
        {
        }
    }
}
