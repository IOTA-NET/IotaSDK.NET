namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetStrongholdPasswordClearInterval
{
    internal class SetStrongholdPasswordClearIntervalCommandModelData
    {
        public SetStrongholdPasswordClearIntervalCommandModelData(int intervalInMilliseconds)
        {
            IntervalInMilliseconds = intervalInMilliseconds;
        }

        public int IntervalInMilliseconds { get; }
    }
}
