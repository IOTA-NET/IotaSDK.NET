namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDecreaseVotingPower
{
    internal class PrepareDecreaseVotingPowerCommandModelData
    {
        public PrepareDecreaseVotingPowerCommandModelData(string amount)
        {
            Amount = amount;
        }

        public string Amount { get; }
    }
}
