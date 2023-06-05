// <copyright file="EditListVm.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.ViewModels.List;

/// <summary>
/// A VM for editing a <see cref="FomoList"/>
/// </summary>
public class EditListVM
{
    /// <summary>
    /// Gets or sets the id of a <see cref="FomoList"/>.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of a <see cref="FomoList"/>.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a list of <see cref="ItemForListVM"/>s.
    /// </summary>
    public List<ItemForListVM> Items { get; set; }
}