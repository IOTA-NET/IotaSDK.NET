using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /** Filter outputs based on bech32-encoded state controller address. */
    public class StateControllerQuery : IQueryParameter, IAliasQueryParameter
    {
        public StateControllerQuery(string stateController)
        {
            StateController = stateController;
        }

        public string StateController { get; }
    }

}
