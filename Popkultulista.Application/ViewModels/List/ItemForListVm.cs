// <copyright file="ItemForListVm.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.ViewModels.List;

using Popkultulista.Domain.Models;

/// <summary>
/// A ViewModel for an item inside a <see cref="ListVM"/>.
/// </summary>
public class ItemForListVM
{
    /// <summary>
    /// Gets or sets the Id of a <see cref="Item"/>.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of a <see cref="Item>"/>
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the total score of a <see cref="Item"/>
    /// </summary>
    public int TotalScore { get; set; }
}