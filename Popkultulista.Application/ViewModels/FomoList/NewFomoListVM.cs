// <copyright file="NewFomoListVM.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.ViewModels.FomoList;

using Popkultulista.Domain.Models;

/// <summary>
/// A ViewModel for creating a new <see cref="FomoList"/>
/// </summary>
public class NewFomoListVM
{
    /// <summary>
    /// Gets or sets the name of a <see cref="FomoList"/>.
    /// </summary>
    public string Name { get; set; }
}