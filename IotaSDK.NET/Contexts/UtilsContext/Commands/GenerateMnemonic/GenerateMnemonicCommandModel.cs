using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic
{
    internal class GenerateMnemonicCommandModel : SerializableModel
    {
        public string name { get; set; } = "generateMnemonic";
    }
}
