namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareIncreaseVotingPower
{
    internal class PrepareIncreaseVotingPowerCommandModelData
    {
        public PrepareIncreaseVotingPowerCommandModelData(string amount)
        {
            Amount = amount;
        }

        public string Amount { get; }
    }
}
