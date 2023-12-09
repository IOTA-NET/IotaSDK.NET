namespace IotaSDK.NET.Domain.Inputs
{
    /// <summary>
    /// A Treasury input
    /// </summary>
    public class TreasuryInput : Input
    {
        public TreasuryInput(string milestoneId) : base((int)InputType.Treasury)
        {
            MilestoneId = milestoneId;
        }

        /// <summary>
        /// Hexencoded  milestone id of the input.
        /// </summary>
        public string MilestoneId { get; }
    }
}
