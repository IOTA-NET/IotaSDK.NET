namespace IotaSDK.NET.Domain.Query
{
    /** Filter outputs based on bech32-encoded governor (governance controller) address. */
    public class GovernorQuery
    {
        public string Governor { get; }

        public GovernorQuery(string governor)
        {
            Governor = governor;
        }
    }

}
