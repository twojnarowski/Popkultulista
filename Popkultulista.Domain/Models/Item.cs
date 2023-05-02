// <copyright file="Item.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;

/// <summary>
/// /// A class representing am Item on a <see cref="List"/>.
/// </summary>
public class Item : NamedEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Item"/> class.
    /// </summary>
    /// <param name="list">A <see cref="List"/> to which this <see cref="Item"/> belongs.</param>
    /// <param name="totalScore">Total score of this <see cref="Item"/>.</param>
    public Item(List list, int totalScore)
    {
        ArgumentNullException.ThrowIfNull(list);

        this.List = list;
        this.ListId = list.Id;
        this.TotalScore = totalScore;
    }

    /// <summary>
    /// Gets or sets the <see cref="List"/> to which this <see cref="Item"/> belongs.
    /// </summary>
    public List List { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of the <see cref="List"/> to which this <see cref="Item"/> belongs.
    /// </summary>
    public Guid ListId { get; set; }

    /// <summary>
    /// Gets the <see cref="Vote"/>s made on this <see cref="Item"/>.
    /// </summary>
    public ICollection<Vote> Votes { get; } = null!;

    /// <summary>
    /// Gets or sets the total score of the <see cref="Item"/>.
    /// </summary>
    public int TotalScore { get; set; }
}