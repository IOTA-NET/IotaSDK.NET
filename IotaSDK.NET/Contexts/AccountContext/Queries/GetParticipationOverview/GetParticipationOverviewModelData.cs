using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationOverview
{
    internal class GetParticipationOverviewModelData
    {
        public GetParticipationOverviewModelData(List<string>? eventIds=null)
        {
            EventIds = eventIds;
        }

        public List<string>? EventIds { get; }
    }
}
