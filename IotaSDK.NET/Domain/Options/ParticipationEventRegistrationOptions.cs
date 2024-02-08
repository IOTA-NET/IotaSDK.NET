using IotaSDK.NET.Domain.Network;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Options
{
    /// <summary>
    /// Options when registering participation events.
    /// </summary>
    public class ParticipationEventRegistrationOptions
    {
        public ParticipationEventRegistrationOptions(Node node, List<string>? eventsToRegister, List<string>? eventsToIgnore)
        {
            Node = node;
            EventsToRegister = eventsToRegister;
            EventsToIgnore = eventsToIgnore;
        }

        /// <summary>
        /// The node to register participation events.
        /// </summary>
        public Node Node { get; }

        /// <summary>
        /// The events to register.
        /// If empty, then every event being tracked by the node will be registered.
        /// </summary>
        public List<string>? EventsToRegister { get; }

        /// <summary>
        /// The events to ignore.
        /// </summary>
        public List<string>? EventsToIgnore { get; }
    }
}
