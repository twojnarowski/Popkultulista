// <copyright file="FomoItem.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Popkultulista.Domain.Models.Common;

namespace Popkultulista.Domain.Models;

/// <summary>
///
/// </summary>
public class FomoItem : NamedEntity
{
    public FomoList FomoList { get; set; }

    public Guid FomoListId { get; set; }

    public ICollection<FomoVote> FomoVotes { get; set; }

    public int FomoCoreScore { get; set; }

    public int FomoVotesScore { get; set; }

    public int FomoTotalScore { get; set; }
}