// <copyright file="NewListVM.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.ViewModels.List;

using Popkultulista.Domain.Models;

/// <summary>
/// A ViewModel for creating a new <see cref="List"/>.
/// </summary>
public class NewListVM
{
    /// <summary>
    /// Gets or sets the name of a <see cref="List"/>.
    /// </summary>
    public string Name { get; set; } = default!;
}