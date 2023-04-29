// <copyright file="FomoVote.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;

/// <summary>
///
/// </summary>
public class FomoVote : NamedEntity
{
    public FomoItem FomoItem { get; set; }

    public Guid FomoItemId { get; set; }

    public int Value { get; set; }
}