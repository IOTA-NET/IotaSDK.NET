using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    public class ParticipationEventMap
    {
        public ParticipationEventMap(Dictionary<string, ParticipationEventWithNodes> eventMaps)
        {
            EventMaps = eventMaps;
        }

        public Dictionary<string, ParticipationEventWithNodes> EventMaps { get; }
    }
}
