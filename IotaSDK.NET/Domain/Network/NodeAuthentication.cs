using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Network
{
    public class NodeAuthentication
    {
        public NodeAuthentication(string? jwt, string? username, string? password)
        {
            Jwt = jwt;

            if(username != null && password != null)
            {
                BasicAuthNamePwd = new List<string>() { username!, password! };
            }
        }

        public string? Jwt { get; set; }

        public List<string>? BasicAuthNamePwd { get; set; }
    }
}
