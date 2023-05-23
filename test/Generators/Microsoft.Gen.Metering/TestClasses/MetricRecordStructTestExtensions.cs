// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if ROSLYN_4_0_OR_GREATER

using System.Diagnostics.Metrics;
using Microsoft.Extensions.Telemetry.Metering;

namespace TestClasses
{
    internal partial record struct MetricRecordStructTestExtensions(string Name, string Address)
    {
        [Counter<int>]
        public static partial CounterFromRecordStruct CreateCounterFromRecordStruct(Meter meter);
    }
}

#endif