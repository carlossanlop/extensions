﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Telemetry.Enrichment;
using Microsoft.Shared.Diagnostics;
using Microsoft.Shared.Text;

namespace Microsoft.Extensions.Telemetry.Enrichment;

/// <summary>
/// Enriches logs with process information.
/// </summary>
internal sealed class ProcessLogEnricher : ILogEnricher
{
    [ThreadStatic]
    private static string? _threadId;
    private readonly bool _threadIdEnabled;

    private readonly string? _processId;

    public ProcessLogEnricher(IOptions<ProcessLogEnricherOptions> options)
    {
        var enricherOptions = Throw.IfMemberNull(options, options.Value);

        _threadIdEnabled = enricherOptions.ThreadId;

        if (enricherOptions.ProcessId)
        {
#if NET5_0_OR_GREATER
            var pid = Environment.ProcessId;
#else
            var pid = System.Diagnostics.Process.GetCurrentProcess().Id;
#endif

            _processId = pid.ToInvariantString();
        }
    }

    public void Enrich(IEnrichmentPropertyBag enrichmentBag)
    {
        if (_processId != null)
        {
            enrichmentBag.Add(ProcessEnricherDimensions.ProcessId, _processId);
        }

        if (_threadIdEnabled)
        {
#pragma warning disable S2696 // Instance members should not write to "static" fields
            _threadId ??= Environment.CurrentManagedThreadId.ToInvariantString();
#pragma warning restore S2696 // Instance members should not write to "static" fields

            enrichmentBag.Add(ProcessEnricherDimensions.ThreadId, _threadId);
        }
    }
}