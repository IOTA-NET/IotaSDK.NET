using IotaSDK.NET.Domain.Transactions.Payloads;
using IotaSDK.NET.Domain.Transactions.Strategy;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Transactions
{
    public class BurnIds
    {
        /** Aliases to burn */
        public List<string>? Aliases { get; set; }

        /** NFTs to burn */
        public List<string>? Nfts { get; set; }

        /** Foundries to burn */
        public List<string>? Foundries { get; set; }

        /** Amounts of native tokens to burn */
        public Dictionary<string, ulong>? NativeTokens { get; set; }
    }
    public class TransactionOptions
    {
        /// <summary>
        /// The strategy applied for base coin remainders.
        /// </summary>
        public RemainderValueStrategy? RemainderValueStrategy { get; set; } = new ReuseAddressStrategy();

        /// <summary>
        /// An optional tagged data payload.
        /// </summary>
        public TaggedDataPayload? TaggedDataPayload { get; set; }

        /// <summary>
        /// Custom inputs that should be used for the transaction.
        /// If custom inputs are provided, only those are used.
        /// If also other additional inputs should be used, `mandatoryInputs` should be used instead.
        /// </summary>

        public List<string>? CustomInputs { get; set; }

        /// <summary>
        /// Inputs that must be used for the transaction.
        /// </summary>
        public List<string>? MandatoryInputs { get; set; }

        /// <summary>
        /// Optional note, that is only stored locally
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Specifies what needs to be burned during input selection.
        /// </summary>
        public BurnIds? Burn { get; set; }
        /// <summary>
        /// Whether to allow sending a micro amount.
        /// </summary>
        public bool AllowMicroAmount { get; set; } = true;

        public TransactionOptions AddBurnInformation(BurnIds burn)
        {
            Burn = burn;
            return this;
        }

        public TransactionOptions SetAllowMicroAmount(bool allowMicroAmount)
        {
            AllowMicroAmount = allowMicroAmount;
            return this;
        }
        public TransactionOptions AddTaggedDataPayload(string tag, string payload)
        {
            TaggedDataPayload = new TaggedDataPayload(tag, payload);
            return this;
        }

        public TransactionOptions SetNote(string note)
        {
            Note = note;
            return this;
        }

        public TransactionOptions AddCustomInputs(string input)
        {
            if (CustomInputs == null)
                CustomInputs = new List<string>();
            CustomInputs.Add(input);

            return this;
        }
    }
}
