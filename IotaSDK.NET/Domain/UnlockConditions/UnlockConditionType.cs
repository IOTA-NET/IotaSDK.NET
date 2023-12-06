namespace IotaSDK.NET.Domain.UnlockConditions
{
    /**
     * All of the unlock condition types.
     */
    public enum UnlockConditionType
    {
        /** An address unlock condition. */
        Address = 0,
        /** A storage deposit return unlock condition. */
        StorageDepositReturn = 1,
        /** A timelock unlock condition. */
        Timelock = 2,
        /** An expiration unlock condition. */
        Expiration = 3,
        /** A state controller address unlock condition. */
        StateControllerAddress = 4,
        /** A governor address unlock condition. */
        GovernorAddress = 5,
        /** An immutable alias address unlock condition. */
        ImmutableAliasAddress = 6,
    }
}
