namespace IotaSDK.NET.Domain.Outputs
{
    public class TreasuryOutput : Output
    {
        public TreasuryOutput(string amount) : base(amount, (int)OutputType.Treasury)
        {
        }
    }
}
