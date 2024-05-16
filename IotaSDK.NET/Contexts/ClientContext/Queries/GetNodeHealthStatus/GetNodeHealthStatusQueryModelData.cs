namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNodeHealthStatus
{
    internal class GetNodeHealthStatusQueryModelData
    {
        public GetNodeHealthStatusQueryModelData(string url)
        {
            Url = url;
        }

        public string Url { get; }
    }
}
