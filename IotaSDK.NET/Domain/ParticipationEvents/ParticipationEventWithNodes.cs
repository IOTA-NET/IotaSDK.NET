using IotaSDK.NET.Domain.Network;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{

    /// <summary>
    /// A participation event with the provided client nodes.
    /// </summary>
    public class ParticipationEventWithNodes
    {
        public ParticipationEventWithNodes(string id, ParticipationEventData data, List<Node> nodes)
        {
            Id = id;
            Data = data;
            Nodes = nodes;
        }

        /// <summary>
        /// The event id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Information about a voting or staking event
        /// </summary>
        public ParticipationEventData Data { get; }


        /// <summary>
        /// Provided client nodes for this event.
        /// </summary>
        public List<Node> Nodes { get; }
    }
}
