using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.ComputeStorageDeposit
{
    internal class ComputeStorageDepositCommand : RustBridgeRequest<string>
    {
        public ComputeStorageDepositCommand(Output output, Rent rent, string rustMethodName) : base(rustMethodName)
        {
            Output = output;
            Rent = rent;
        }

        public Output Output { get; }
        public Rent Rent { get; }
    }
}
