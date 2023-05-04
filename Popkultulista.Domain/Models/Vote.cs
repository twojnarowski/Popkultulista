// <copyright file="Vote.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;
using Popkultulista.Domain.Models.Identity;

/// <summary>
/// A class representing a vote made by a user on someone's list's item.
/// </summary>
public class Vote : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Vote"/> class.
    /// </summary>
    /// <param name="item"><see cref="Item"/> for which the vote was added.</param>
    /// <param name="user"><see cref="User"/> making the vote.</param>
    /// <param name="isUpvote">True for upvote.</param>
    public Vote(Item item, User user, bool isUpvote)
        : base()
    {
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(user);

        this.Item = item;
        this.ItemId = item.Id;
        this.User = user;
        this.UserId = user.Id;
        this.IsUpvote = isUpvote;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vote"/> class.
    /// </summary>
    public Vote()
        : base()
    {
    }

    /// <summary>
    /// Gets or sets the <see cref="Item"/> for which the Vote is.
    /// </summary>
    public Item Item { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of the <see cref="Item"/> for which the Vote is.
    /// </summary>
    public Guid ItemId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="User"/> who made the <see cref="Vote"/>.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of a User who made this <see cref="Vote"/>.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this vote is positive or negative.
    /// </summary>
    public bool IsUpvote { get; set; }
}