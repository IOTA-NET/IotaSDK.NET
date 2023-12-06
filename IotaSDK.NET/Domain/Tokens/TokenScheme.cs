using System;

namespace IotaSDK.NET.Domain.Tokens
{
    public abstract class TokenScheme
    {
        public TokenScheme(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public TokenSchemeType GetTokenSchemeType()
        {
            if (Enum.IsDefined(typeof(TokenSchemeType), this.Type))
            {
                return (TokenSchemeType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid TokenSchemeType value");
            }
        }
    }
}
