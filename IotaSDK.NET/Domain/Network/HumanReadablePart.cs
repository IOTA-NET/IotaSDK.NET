﻿using System;

namespace IotaSDK.NET.Domain.Network
{
    public enum HumanReadablePart
    {
        Iota,
        Atoi,
        Smr,
        Rms,
        Test
    }

    internal static class HumanReadablePartEnumConverter
    {
        public static string Convert(HumanReadablePart part)
        {
            switch (part)
            {
                case HumanReadablePart.Iota:
                    return "iota";
                case HumanReadablePart.Atoi:
                    return "atoi";
                case HumanReadablePart.Smr:
                    return "smr";
                case HumanReadablePart.Rms:
                    return "rms";
                case HumanReadablePart.Test:
                    return "tst";
                default:
                    throw new ArgumentException("Failure to convert, Unknown enum value of HumanReadablePart");
            }
        }
    }
}
