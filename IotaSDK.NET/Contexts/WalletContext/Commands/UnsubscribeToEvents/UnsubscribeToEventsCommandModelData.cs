using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.UnsubscribeToEvents
{
    internal class UnsubscribeToEventsCommandModelData
    {
        public UnsubscribeToEventsCommandModelData(List<string> eventTypes)
        {
            EventTypes = eventTypes;
        }

        public List<string> EventTypes { get; }
    }
}
