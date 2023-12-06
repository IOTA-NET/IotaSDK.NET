namespace IotaSDK.NET.Domain.Features
{
    /// <summary>
    ///  A Tag feature.
    /// </summary>
    public class TagFeature : Feature
    {
        public TagFeature(int type, string tag) : base(type)
        {
            Tag = tag;
        }

        /// <summary>
        ///  Defines a tag for the data
        /// </summary>
        public string Tag { get; }
    }
}
