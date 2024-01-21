using IotaSDK.NET.Domain.Outputs;

namespace IotaSDK.NET.Domain.Events
{
    /// <summary>
    /// A 'spent output' wallet event.
    /// </summary>
    public class SpentOutputWalletEvent : WalletEvent
    {

        public SpentOutputWalletEvent(OutputData output) : base((int)WalletEventType.SpentOutput)
        {
            Output = output;
        }

        /// <summary>
        /// The spent output.
        /// </summary>
        public OutputData Output { get; }
    }
}
