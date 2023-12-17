namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput
{
    internal class GetOutputQueryModelData
    {
        public GetOutputQueryModelData(string outputId)
        {
            OutputId = outputId;
        }

        public string OutputId { get; }
    }
}
