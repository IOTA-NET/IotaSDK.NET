namespace IotaSDK.NET.Domain.Accounts
{
    /// <summary>
    /// Specifies what outputs should be synced for the address of an alias output
    /// </summary>
    public class AliasSyncOptions : AccountSyncOptions
    {

        /// <summary>
        ///  Whether to sync foundry outputs.
        /// </summary>
        public bool? FoundryOutputs { get; set; }
    }
}
