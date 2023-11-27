using System;
using System.Collections.Generic;
using System.Text;

namespace IotaSDK.NET.Domain.Options
{
    public class SecretManagerOptions
    {
        public StrongholdOptions Stronghold { get; set; } = new StrongholdOptions();

    }
    public class StrongholdOptions
    {
        public string Password { get; set; } = "password";
        public string SnapshotPath { get; set; } = "./stronghold";


    }
}
