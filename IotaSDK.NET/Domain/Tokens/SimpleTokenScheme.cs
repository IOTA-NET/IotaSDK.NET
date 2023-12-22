using IotaSDK.NET.Common.Extensions;

namespace IotaSDK.NET.Domain.Tokens
{
    public class SimpleTokenScheme : TokenScheme
    {
        public SimpleTokenScheme(string mintedTokens, string meltedTokens, string maximumSupply)
            : base((int)TokenSchemeType.Simple)
        {
            MintedTokens = mintedTokens.FromHexToULong();
            MeltedTokens = meltedTokens.FromHexToULong();
            MaximumSupply = maximumSupply.FromHexToULong();
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
