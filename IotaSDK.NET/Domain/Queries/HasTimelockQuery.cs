namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs based on the presence of timelock unlock condition.
    /// </summary>
    public class HasTimelockQuery
    {
        public HasTimelockQuery(bool hasTimelock)
        {
            HasTimelock = hasTimelock;
        }

        public bool HasTimelock { get; }
    }

}
