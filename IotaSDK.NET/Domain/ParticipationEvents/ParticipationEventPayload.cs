using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(VotingEventPayload), (int)ParticipationEventType.Voting)]
    [JsonSubtypes.KnownSubType(typeof(StakingEventPayload), (int)ParticipationEventType.Staking)]
    public abstract class ParticipationEventPayload
    {
        public ParticipationEventPayload(int type)
        {
            Type = type;
        }
        public int Type { get; }

        public ParticipationEventType GetParticipationEventType()
        {
            if (Enum.IsDefined(typeof(ParticipationEventType), this.Type))
            {
                return (ParticipationEventType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid ParticipationEventType value");
            }
        }
    }
}
