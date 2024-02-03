using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareVote
{
    internal class PrepareVoteCommandModelData
    {
        public PrepareVoteCommandModelData(string? eventId=null, List<int>? answers = null)
        {
            EventId = eventId;
            Answers = answers;
        }

        public string? EventId { get; }
        public List<int>? Answers { get; }
    }
}
