namespace IotaSDK.NET.Domain.Tokens
{
    /// <summary>
    /// Defines the parameters of rent cost calculations on objects which take node resources.
    /// </summary>
    public class Rent
    {
        public Rent(int vByteCost, int vByteFactorData, int vByteFactorKey)
        {
            VByteCost = vByteCost;
            VByteFactorData = vByteFactorData;
            VByteFactorKey = vByteFactorKey;
        }

        /// <summary>
        /// Defines the rent of a single virtual byte denoted in IOTA token.
        /// </summary>
        public int VByteCost { get; }

        /// <summary>
        /// The factor to be used for data only fields.
        /// </summary>
        public int VByteFactorData { get; }

        /// <summary>
        /// The factor to be used for key/lookup generating fields.
        /// </summary>
        public int VByteFactorKey { get; }
    }

}
