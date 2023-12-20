namespace IotaSDK.NET.Domain.Faucet
{
    public class FaucetResponse
    {
        public FaucetResponse(string address, int waitingRequests)
        {
            Address = address;
            WaitingRequests = waitingRequests;
        }

        public string Address { get; }
        public int WaitingRequests { get; }
    }
}
