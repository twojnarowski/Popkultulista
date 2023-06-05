// <copyright file="FomoItemForListVm.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Popkultulista.Domain.Models;

namespace Popkultulista.Application.ViewModels.FomoList;

/// <summary>
/// A ViewModel for a <see cref="FomoItem"/> for a <see cref="FomoListVM"/>.
/// </summary>
public class FomoItemForListVM
{
    /// <summary>
    /// Gets or sets the Id of a <see cref="FomoItem"/>.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of a <see cref="FomoItem"/>
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the total score of a <see cref="FomoItem"/>
    /// </summary>
    public int TotalFomoScore { get; set; }
}