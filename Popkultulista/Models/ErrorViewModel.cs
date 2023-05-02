// <copyright file="ErrorViewModel.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Models;

/// <summary>
/// Error View Model.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Gets or sets the Request Id.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Gets a value indicating whether RequestId can be shown.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
}