// <copyright file="List.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Popkultulista.Domain.Models.Common;

namespace Popkultulista.Domain.Models;

/// <summary>
/// A class representing a list of items.
/// </summary>
public class List : NamedEntity
{
    public ICollection<Item> Items { get; set; }

    public bool IsPrivate { get; set; }
}