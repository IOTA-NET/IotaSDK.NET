namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// An object containing an account's entire participation overview.
    /// </summary>
    public class ParticipationOverview
    {
        public Participations Participations { get; set; }

        public ParticipationOverview()
        {
            Participations = new Participations();
        }
    }


}
