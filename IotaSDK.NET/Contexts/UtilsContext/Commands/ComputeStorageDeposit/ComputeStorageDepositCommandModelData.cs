using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.ComputeStorageDeposit
{
    internal class ComputeStorageDepositCommandModelData
    {
        public ComputeStorageDepositCommandModelData(Output output, Rent rent)
        {
            Output = output;
            Rent = rent;
        }

        public Output Output { get; }
        public Rent Rent { get; }
    }
}
