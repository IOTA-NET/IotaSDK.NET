namespace IotaSDK.NET.Domain.Accounts
{
    public class NativeTokenBalance
    {
        public NativeTokenBalance(string tokenId, ulong total, ulong available, string? metadata)
        {
            TokenId = tokenId;
            Total = total;
            Available = available;
            Metadata = metadata;
        }

        /// <summary>
        /// Hexencoded native token id
        /// </summary>
        public string TokenId { get; set; }

        /// <summary>
        /// The total native token balance
        /// </summary>
        public ulong Total { get; }

        /// <summary>
        /// The available amount of the total native token balance
        /// </summary>
        public ulong Available { get; }

        /// <summary>
        /// Some metadata of the native token
        /// </summary>
        public string? Metadata { get; }
    }
}
