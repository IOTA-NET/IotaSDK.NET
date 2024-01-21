using System;

namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    /// The base class for transaction progresses.
    /// </summary>
    public abstract class TransactionProgress
    {
        public TransactionProgress(int type)
        {
            Type = type;
        }

        /// <summary>
        /// The type of transaction progress.
        /// </summary>
        public int Type { get; }

        public TransactionProgressType GetOutputType()
        {
            if (Enum.IsDefined(typeof(TransactionProgressType), Type))
            {
                return (TransactionProgressType)Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(Type), "Invalid TransactionProgressType value");
            }
        }
    }
}
