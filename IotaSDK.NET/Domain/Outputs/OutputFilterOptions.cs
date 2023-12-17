using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class OutputFilterOptions
    {
        /// <summary>
        /// Filter all outputs where the booked milestone index is below the specified timestamp
        /// </summary>
        public uint? LowerBoundBookedTimestamp { get; set; }

        /// <summary>
        /// Filter all outputs where the booked milestone index is above the specified timestamp
        /// </summary>
        public uint? UpperBoundBookedTimestamp { get; set; }

        /// <summary>
        /// Filter all outputs for the provided types (Basic = 3, Alias = 4, Foundry = 5, NFT = 6)
        /// </summary>
        public List<int>? OutputTypes { get; set; }

        /// <summary>
        /// Return all alias outputs matching these IDs.
        /// </summary>
        public List<string>? AliasIds { get; set; }

        /// <summary>
        /// Return all foundry outputs matching these IDs.
        /// </summary>
        public List<string>? FoundryIds { get; set; }

        /// <summary>
        /// Return all NFT outputs matching these IDs.
        /// </summary>
        public List<string>? NftIds { get; set; }
    }
}
