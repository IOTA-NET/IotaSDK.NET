using System;
using System.Collections.Generic;
using System.Text;

namespace IotaSDK.NET.Domain.Outputs
{

    /**
     * All of the output types.
     */
    public enum OutputType
    {
        /** A Treasury output. */
        Treasury = 2,
        /** A Basic output. */
        Basic = 3,
        /** An Alias output. */
        Alias = 4,
        /** A Foundry output. */
        Foundry = 5,
        /** An NFT output. */
        Nft = 6,
    }
}
