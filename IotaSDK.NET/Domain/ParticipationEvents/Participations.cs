using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    public class Participations
    {
        /// <summary>
        /// eventID mapped to outputId mapped to TrackedParticipationOVerview
        /// </summary>
        public Dictionary<string, Dictionary<string, TrackedParticipationOverview>> EventParticipations { get; set; }

        public Participations()
        {
            EventParticipations = new Dictionary<string, Dictionary<string, TrackedParticipationOverview>>();
        }
    }


}
