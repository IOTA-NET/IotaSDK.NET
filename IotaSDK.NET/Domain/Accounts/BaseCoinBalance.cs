namespace IotaSDK.NET.Domain.Accounts
{
    public class BaseCoinBalance
    {
        public BaseCoinBalance(string total, string available, string votingPower)
        {
            Total = total;
            Available = available;
            VotingPower = votingPower;
        }

        /// <summary>
        /// The total amount of all the outputs
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// The amount in all the outputs that aren't used in a transaction
        /// </summary>
        public string Available { get; set; }

        /// <summary>
        ///  Voting power
        /// </summary>
        public string VotingPower { get; set; }
    }
}