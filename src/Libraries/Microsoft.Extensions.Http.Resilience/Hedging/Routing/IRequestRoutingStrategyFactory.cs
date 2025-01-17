﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace Microsoft.Extensions.Http.Resilience;

/// <summary>
/// Defines a factory for creation of request routing strategies.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IRequestRoutingStrategyFactory
{
    /// <summary>
    /// Creates a new instance of <seealso cref="IRequestRoutingStrategy"/>.
    /// </summary>
    /// <returns>The RequestRoutingStragegy for providing the routes.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    IRequestRoutingStrategy CreateRoutingStrategy();
}
