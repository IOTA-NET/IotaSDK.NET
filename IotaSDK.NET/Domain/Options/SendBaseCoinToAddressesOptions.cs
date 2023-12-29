using System;

namespace IotaSDK.NET.Domain.Options
{
    /// <summary>
    /// Address with a base token amount 
    /// </summary>
    public class SendBaseCoinToAddressOptions
    {
        /// <summary>
        /// The Bech32 address to send the amount to
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The amount to send
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Bech32 encoded address, to which the storage deposit will be returned if one is necessary
        /// given the provided amount. If a storage deposit is needed and a return address is not provided, it will
        /// default to the first address of the account.
        /// </summary>
        public string ReturnAddress { get; set; }

        /// <summary>
        /// Expiration in seconds, after which the output will be available for the sender again, if not spent by the
        /// receiver already. The expiration will only be used if one is necessary given the provided amount. If an
        /// expiration is needed but not provided, it will default to one day.
        /// </summary>
        public int? Expiration { get; set; }

        public SendBaseCoinToAddressOptions(string address, ulong amount, string returnAddress = null, int? expiration = null)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Amount = amount.ToString();
            ReturnAddress = returnAddress;
            Expiration = expiration;
        }
    }
}
