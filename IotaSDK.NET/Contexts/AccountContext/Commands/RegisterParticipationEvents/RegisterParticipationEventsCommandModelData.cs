using IotaSDK.NET.Domain.Options;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RegisterParticipationEvents
{
    internal class RegisterParticipationEventsCommandModelData
    {
        public RegisterParticipationEventsCommandModelData(ParticipationEventRegistrationOptions options)
        {
            Options = options;
        }

        public ParticipationEventRegistrationOptions Options { get; }
    }
}
