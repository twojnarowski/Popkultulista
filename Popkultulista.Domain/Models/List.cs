// <copyright file="List.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;

/// <summary>
/// A class representing a list of items.
/// </summary>
public class List : NamedEntity
{
    /// <summary>
    /// Gets a collection of <see cref="Item"/>s on this list.
    /// </summary>
    public ICollection<Item> Items { get; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="List"/> is private to its owner.
    /// </summary>
    public bool IsPrivate { get; set; }
}