using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class FoundryOutput : ImmutableFeaturesOutput
    {
        public FoundryOutput(
            string amount,
            int serialNumber,
            List<UnlockCondition> unlockConditions,
            TokenScheme tokenScheme)
            : base(amount, (int)OutputType.Foundry, unlockConditions, null)
        {
            SerialNumber = serialNumber;
            TokenScheme = tokenScheme;
        }

        /// <summary>
        /// The serial number of the Foundry with respect to the controlling alias.
        /// </summary>
        public int SerialNumber { get; }

        /// <summary>
        /// The token scheme for the Foundry.
        /// </summary>
        public TokenScheme TokenScheme { get; }
    }
}
