namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias
{
    internal class SetAliasCommandModelData
    {
        public SetAliasCommandModelData(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
