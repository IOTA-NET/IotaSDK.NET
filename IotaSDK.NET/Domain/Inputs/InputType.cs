using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions.EssenceTypes;

namespace IotaSDK.NET.Domain.Inputs
{
    public enum InputType
    {
        /** A UTXO input. */
        UTXO = 0,
        /** The treasury input. */
        Treasury = 1,
    }
    }
