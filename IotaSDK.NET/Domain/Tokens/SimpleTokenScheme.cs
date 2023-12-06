namespace IotaSDK.NET.Domain.Tokens
{
    public class SimpleTokenScheme : TokenScheme
    {
        public SimpleTokenScheme(ulong mintedTokens, ulong meltedTokens, ulong maximumSupply)
            :base((int)TokenSchemeType.Simple)
        {
            MintedTokens = mintedTokens;
            MeltedTokens = meltedTokens;
            MaximumSupply = maximumSupply;
        }



        /// <summary>
        /// Amount of tokens minted by this foundry.
        /// </summary>
        public ulong MintedTokens { get; set; }


        /// <summary>
        /// Amount of tokens melted by this foundry.
        /// </summary>
        public ulong MeltedTokens { get; set; }


        /// <summary>
        /// Maximum supply of tokens controlled by this foundry.
        /// </summary>
        public ulong MaximumSupply { get; set; }
    }
}
