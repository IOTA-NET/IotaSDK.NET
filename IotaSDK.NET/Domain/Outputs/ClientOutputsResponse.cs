using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    /// <summary>
    /// Details of an outputs response from the indexer plugin.
    /// </summary>
    public class ClientOutputsResponse
    {
        /// <summary>
        /// The ledger index at which these outputs where available at.
        /// </summary>
        public int LedgerIndex { get; set; }

        /// <summary>
        /// The maximum count of results that are returned by the node.
        /// </summary>
        public string PageSize { get; set; } = string.Empty;

        /// <summary>
        /// The cursor to use for getting the next results.
        /// </summary>
        public string? Cursor { get; set; }


        /// <summary>
        /// The output IDs (transaction hash + output index) of the outputs on this address.
        /// </summary>
        public List<string> Items{ get; set; } = new List<string>();
    }
}
