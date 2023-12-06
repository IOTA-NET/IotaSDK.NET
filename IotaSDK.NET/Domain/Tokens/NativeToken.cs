namespace IotaSDK.NET.Domain.Tokens
{
    public class NativeToken
    {
        public NativeToken(string id, ulong amount)
        {
            Id = id;
            Amount = amount;
        }

        /// <summary>
        /// Identifier of the native token.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Amount of native tokens of the given Token ID.
        /// </summary>
        public ulong Amount { get; set; }
    }
}
