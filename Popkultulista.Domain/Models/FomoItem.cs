// <copyright file="FomoItem.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using System.Collections.Generic;
using Popkultulista.Domain.Models.Common;

/// <summary>
/// A class representing a FomoItem on a FomoList.
/// </summary>
public class FomoItem : NamedEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FomoItem"/> class.
    /// </summary>
    /// <param name="fomoList">A <see cref="FomoList"/> to which this <see cref="FomoItem"/> belongs.</param>
    /// <param name="fomoCoreScore">Core score of the <see cref="FomoItem"/>.</param>
    /// <param name="name">Name of the <see cref="FomoItem"/>.</param>
    /// <param name="createdBy"><see cref="Guid"/> of the user creating this <see cref="FomoItem"/>.</param>
    public FomoItem(FomoList fomoList, int fomoCoreScore, string name, Guid createdBy)
        : base(name, createdBy)
    {
        ArgumentNullException.ThrowIfNull(fomoList);

        this.FomoList = fomoList;
        this.FomoListId = fomoList.Id;
        this.FomoCoreScore = fomoCoreScore;
        this.FomoTotalScore = fomoCoreScore + this.FomoVotesScore;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FomoItem"/> class.
    /// </summary>
    private FomoItem()
        : base()
    {
    }

    /// <summary>
    /// Gets or sets the <see cref="FomoList"/> to which this <see cref="FomoItem"/> belongs.
    /// </summary>
    public FomoList FomoList { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of the <see cref="FomoList"/> to which this <see cref="FomoItem"/> belongs.
    /// </summary>
    public Guid FomoListId { get; set; }

    /// <summary>
    /// Gets the <see cref="FomoVote"/>s made on this <see cref="FomoItem"/>.
    /// </summary>
    public ICollection<FomoVote> FomoVotes { get; } = null!;

    /// <summary>
    /// Gets or sets the base Fomo score of the <see cref="FomoItem"/>.
    /// </summary>
    public int FomoCoreScore { get; set; }

    /// <summary>
    /// Gets or sets the score of the <see cref="FomoItem"/> based on votes.
    /// </summary>
    public int FomoVotesScore { get; set; }

    /// <summary>
    /// Gets or sets the total score of the <see cref="FomoItem"/>.
    /// </summary>
    public int FomoTotalScore { get; set; }
}