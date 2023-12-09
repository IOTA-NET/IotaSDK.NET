using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET
{
    public class Account : IAccount
    {
        public Account(int index, string username)
        {
            Index = index;
            Username = username;
        }

        public int Index { get; }
        public string Username { get; }
    }
}
