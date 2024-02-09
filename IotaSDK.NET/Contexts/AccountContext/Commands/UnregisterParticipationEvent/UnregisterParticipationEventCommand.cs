using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.UnregisterParticipationEvent
{
    internal class UnregisterParticipationEventCommand : AccountRequest
    {
        public UnregisterParticipationEventCommand(IntPtr walletHandle, int accountIndex, string participationEventId) : base(walletHandle, accountIndex)
        {
            ParticipationEventId = participationEventId;
        }

        public string ParticipationEventId { get; }
    }
}
