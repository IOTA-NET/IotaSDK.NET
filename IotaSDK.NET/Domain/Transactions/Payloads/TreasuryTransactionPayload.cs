using IotaSDK.NET.Domain.Inputs;
using IotaSDK.NET.Domain.Outputs;

namespace IotaSDK.NET.Domain.Transactions.Payloads
{
    public class TreasuryTransactionPayload : Payload
    {
        public TreasuryTransactionPayload(TreasuryInput input, TreasuryOutput output)
            : base((int)PayloadType.TreasuryTransaction)
        {
            Input = input;
            Output = output;
        }

        /// <summary>
        /// The input of this transaction.
        /// </summary>
        public TreasuryInput Input { get; set; }

        /// <summary>
        /// The output of this transaction.
        /// </summary>
        public TreasuryOutput Output { get; set; }
    }
}
