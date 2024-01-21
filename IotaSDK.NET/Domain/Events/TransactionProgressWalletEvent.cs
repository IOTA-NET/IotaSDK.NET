using IotaSDK.NET.Domain.Events.TransactionProgresses;

namespace IotaSDK.NET.Domain.Events
{
    public class TransactionProgressWalletEvent : WalletEvent
    {
        public TransactionProgressWalletEvent(TransactionProgress progress) : base((int)WalletEventType.TransactionProgress)
        {
            Progress = progress;
        }

        public TransactionProgress Progress { get; }
    }
}
