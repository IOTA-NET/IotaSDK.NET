using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.ParticipationEvents;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RegisterParticipationEvents
{
    internal class RegisterParticipationEventsCommand : AccountRequest<IotaSDKResponse<ParticipationEventMap>>
    {
        public RegisterParticipationEventsCommand(IntPtr walletHandle, int accountIndex, ParticipationEventRegistrationOptions participationEventRegistrationOptions) : base(walletHandle, accountIndex)
        {
            ParticipationEventRegistrationOptions = participationEventRegistrationOptions;
        }

        public ParticipationEventRegistrationOptions ParticipationEventRegistrationOptions { get; }
    }
}
