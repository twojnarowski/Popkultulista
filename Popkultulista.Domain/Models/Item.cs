// <copyright file="Item.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Popkultulista.Domain.Models.Common;

namespace Popkultulista.Domain.Models;

/// <summary>
///
/// </summary>
public class Item : NamedEntity
{
    public List List { get; set; }

    public Guid ListId { get; set; }

    public ICollection<Vote> Votes { get; set; }

    public int TotalScore { get; set; }
}