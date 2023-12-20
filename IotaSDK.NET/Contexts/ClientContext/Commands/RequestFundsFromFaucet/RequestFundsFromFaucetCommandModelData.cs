namespace IotaSDK.NET.Contexts.ClientContext.Commands.RequestFundsFromFaucet
{
    internal class RequestFundsFromFaucetCommandModelData
    {
        public RequestFundsFromFaucetCommandModelData(string url, string address)
        {
            Url = url;
            Address = address;
        }

        public string Url { get; }
        public string Address { get; }
    }
}
