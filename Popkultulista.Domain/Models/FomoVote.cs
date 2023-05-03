// <copyright file="FomoVote.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;
using Popkultulista.Domain.Models.Identity;

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
    /// <param name="user">User who made this <see cref="FomoVote"/>.</param>
    public FomoVote(FomoItem fomoItem, int value, User user)
    {
        ArgumentNullException.ThrowIfNull(fomoItem);
        ArgumentNullException.ThrowIfNull(user);

        this.FomoItem = fomoItem;
        this.FomoItemId = fomoItem.Id;
        this.Value = value;
        this.User = user;
        this.UserId = user.Id;
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

    /// <summary>
    /// Gets or sets the <see cref="User"/> who made the <see cref="Vote"/>.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of a User who made this <see cref="Vote"/>.
    /// </summary>
    public Guid UserId { get; set; }
}