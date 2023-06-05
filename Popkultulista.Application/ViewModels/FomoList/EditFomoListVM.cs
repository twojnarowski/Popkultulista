// <copyright file="EditFomoListVM.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.ViewModels.FomoList;

/// <summary>
/// A VM for displaying a <see cref="FomoList"/>
/// </summary>
public class EditFomoListVM
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
    /// Gets or sets a list of <see cref="FomoItemForListVM"/>s.
    /// </summary>
    public List<FomoItemForListVM> FomoItems { get; set; }
}