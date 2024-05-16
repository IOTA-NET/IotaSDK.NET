namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter for a certain tag
    /// </summary>
    public class TagQuery
    {
        public TagQuery(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; }
    }

}
