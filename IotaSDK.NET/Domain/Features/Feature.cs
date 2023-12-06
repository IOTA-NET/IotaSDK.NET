using System;

namespace IotaSDK.NET.Domain.Features
{
    public abstract class Feature
    {
        public Feature(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public FeatureType GetFeatureType()
        {
            if (Enum.IsDefined(typeof(FeatureType), this.Type))
            {
                return (FeatureType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid FeatureType value");
            }
        }
    }
}
