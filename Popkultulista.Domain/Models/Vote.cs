// <copyright file="Vote.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Popkultulista.Domain.Models.Common;
using Popkultulista.Domain.Models.Identity;

namespace Popkultulista.Domain.Models;

/// <summary>
///
/// </summary>
public class Vote : NamedEntity
{
    public Item Item { get; set; }
    public Guid ItemId { get; set; }

    public User User { get; set; }
    public Guid UserId { get; set; }

    public bool IsUpvote { get; set; }
}