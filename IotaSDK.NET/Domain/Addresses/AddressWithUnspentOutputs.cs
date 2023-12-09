using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Addresses
{
    public class AddressWithUnspentOutputs
    {
        public AddressWithUnspentOutputs(string address)
        {
            Address = address;
        }

        /// <summary>
        /// The Bech32 address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The address key index
        /// </summary>
        public int KeyIndex { get; set; }

        /// <summary>
        /// Whether the address is a public or an internal (change) address
        /// </summary>
        public bool Internal { get; set; }

        /// <summary>
        /// The IDs of associated unspent outputs
        /// </summary>
        public List<string> OutputIds { get; set; } = new List<string>();
    }
}
