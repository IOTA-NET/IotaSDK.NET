namespace IotaSDK.NET.Domain.Network
{
    /// <summary>
    /// A node object for the client.
    /// </summary>
    public class Node
    {
        public Node(string url, NodeAuthentication? auth, bool? disabled)
        {
            Url = url;
            Auth = auth;
            Disabled = disabled;
        }

        /// <summary>
        /// The URL of the node.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// The authentication parameters.
        /// </summary>
        public NodeAuthentication? Auth { get; }

        /// <summary>
        /// Whether the node is disabled or not.
        /// </summary>
        public bool? Disabled { get; }
    }
}
