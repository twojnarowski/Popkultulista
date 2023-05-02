// <copyright file="FomoVote.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;

/// <summary>
/// A class representing a Fomo Vote made on a <see cref="FomoItem"/>.
/// </summary>
public class FomoVote : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FomoVote"/> class.
    /// </summary>
    /// <param name="fomoItem">A <see cref="FomoItem"/> on which this <see cref="FomoVote"/> was made.</param>
    /// <param name="value">Value of the <see cref="FomoVote"/>.</param>
    public FomoVote(FomoItem fomoItem, int value)
    {
        ArgumentNullException.ThrowIfNull(fomoItem);

        this.FomoItem = fomoItem;
        this.FomoItemId = fomoItem.Id;
        this.Value = value;
    }

    /// <summary>
    /// Gets or sets the <see cref="FomoItem"/> on which this <see cref="FomoVote"/> was made.
    /// </summary>
    public FomoItem FomoItem { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of the <see cref="FomoItem"/> on which this <see cref="FomoVote"/> was made.
    /// </summary>
    public Guid FomoItemId { get; set; }

    /// <summary>
    /// Gets or sets the value of the <see cref="FomoVote"/>.
    /// </summary>
    public int Value { get; set; }
}