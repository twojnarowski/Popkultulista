// <copyright file="FomoList.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;

/// <summary>
/// A class representing a list of <see cref="FomoItem"/>s.
/// </summary>
public class FomoList : NamedEntity
{
    /// <summary>
    /// Gets a collection of <see cref="FomoItem"/>s on this list.
    /// </summary>
    public ICollection<FomoItem> FomoItems { get; } = null!;
}