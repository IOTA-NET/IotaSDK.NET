namespace IotaSDK.NET.Domain.Events
{
    public class WalletEventNotification
    {
        public WalletEventNotification(int accountIndex, WalletEvent @event)
        {
            AccountIndex = accountIndex;
            Event = @event;
        }

        public int AccountIndex { get; set; }

        public WalletEvent Event { get; set; }
    }
}
