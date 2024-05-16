using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs based on the presence of timelock unlock condition.
    /// </summary>
    public class HasTimelockQuery : IQueryParameter, INftQueryParameter
    {
        public HasTimelockQuery(bool hasTimelock)
        {
            HasTimelock = hasTimelock;
        }

        public bool HasTimelock { get; }
    }

}
