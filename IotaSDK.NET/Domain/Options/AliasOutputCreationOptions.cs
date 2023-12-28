using IotaSDK.NET.Common.Extensions;

namespace IotaSDK.NET.Domain.Options
{
    /// <summary>
    /// Options for the alias output creation
    /// </summary>
    public class AliasOutputCreationOptions
    {
        public AliasOutputCreationOptions(string? address = null, string? metadata = null, string? immutableMetadata = null, string? stateMetadata = null)
        {
            Address = address;
            Metadata = metadata?.ToHexString();
            ImmutableMetadata = immutableMetadata?.ToHexString();
            StateMetadata = stateMetadata?.ToHexString();
        }

        /// <summary>
        /// Bech32 encoded address to which the Output will be minted. Default will use the first address of the account
        /// </summary>
        public string? Address { get; }

        /// <summary>
        /// Metadata hexstring
        /// </summary>
        public string? Metadata { get; }

        /// <summary>
        /// Immutable Metadata hexstring
        /// </summary>
        public string? ImmutableMetadata { get; }

        /// <summary>
        /// State's hexstring
        /// </summary>
        public string? StateMetadata { get; }
    }
}
