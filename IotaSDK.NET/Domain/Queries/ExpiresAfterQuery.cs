﻿using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Return outputs that expire after a certain Unix timestamp. 
    /// </summary>
    public class ExpiresAfterQuery : IQueryParameter, INftQueryParameter
    {
        public ExpiresAfterQuery(ulong expiresAfter)
        {
            ExpiresAfter = expiresAfter;
        }

        public ulong ExpiresAfter { get; }
    }

}
