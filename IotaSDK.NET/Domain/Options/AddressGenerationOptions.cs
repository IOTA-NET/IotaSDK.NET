namespace IotaSDK.NET.Domain.Options
{
    /// <summary>
    /// Options for address generation, useful with a Ledger Nano SecretManager
    /// </summary>
    public class AddressGenerationOptions
    {
        public AddressGenerationOptions(bool @internal, bool ledgerNanoPrompt)
        {
            Internal = @internal;
            LedgerNanoPrompt = ledgerNanoPrompt;
        }

        public bool Internal { get; }
        public bool LedgerNanoPrompt { get; }
    }
}
